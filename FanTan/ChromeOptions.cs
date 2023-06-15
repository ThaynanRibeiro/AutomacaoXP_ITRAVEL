using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;

namespace Projeto
{
    public class ChromeOptionsGeral
    {
        public static IWebDriver ChromeOptionsMain(bool modoHeadless)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--incognito"); // Ativa o modo anônimo
            options.AddArgument("--start-maximized"); // maximiza pagina
            options.AddArgument("--start-minimized"); // minimiza pagina

            IWebDriver driver = new ChromeDriver(options);

            return driver;
        }

        public static void AtualizaChromeDriver()
        {
            string chromeVersion = GetChromeVersion();
            string chromeDriverVersion = GetChromeDriverVersion(chromeVersion);
            string chromeDriverZipPath = DownloadChromeDriver(chromeDriverVersion);
            ExtractChromeDriver(chromeDriverZipPath);
            DeleteFile(chromeDriverZipPath);

            Console.WriteLine("Atualizado com Sucesso!");
        }

        public static string GetChromeVersion()
        {
            var chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; //Mudar caminho para o caminho que estiver o chrome.exe na máquina
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(chromePath);
            return fileVersionInfo.FileVersion;
        }

        public static string GetChromeDriverVersion(string chromeVersion)
        {
            string url = $"https://chromedriver.chromium.org/downloads";
            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(url);
            chromeVersion = Regex.Match(chromeVersion, @"(\d+\.\d+\.\d+)", RegexOptions.Singleline).Groups[1].Value;
            string value = Regex.Match(html, $@"ChromeDriver\s+{chromeVersion}(\.\d+)", RegexOptions.Singleline).Groups[1].Value;
            chromeVersion = chromeVersion + value;
            value = $"https://chromedriver.storage.googleapis.com/{chromeVersion}/chromedriver_win32.zip";

            return value;
        }

        public static string DownloadChromeDriver(string url)
        {
            string zipPath = Path.Combine(Directory.GetCurrentDirectory(), "chromedriver.zip");
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(url, zipPath);
            }
            return zipPath;
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void MoveFile(string sourceFilePath, string destinationFilePath)
        {
            if (File.Exists(sourceFilePath))
            {
                File.Move(sourceFilePath, destinationFilePath);
            }
        }

        public static void ExtractChromeDriver(string zipPath)
        {
            DeleteFile($"{zipPath.Replace("chromedriver.zip", "")}chromedriver\\chromedriver.exe");
            DeleteFile($"{zipPath.Replace("chromedriver.zip", "")}chromedriver\\LICENSE.chromedriver");
            string extractPath = Path.Combine(Directory.GetCurrentDirectory(), "chromedriver");
            ZipFile.ExtractToDirectory(zipPath, extractPath);

            DeleteFile($"{zipPath.Replace("chromedriver.zip", "")}chromedriver.exe");
            MoveFile($"{zipPath.Replace("chromedriver.zip", "")}chromedriver\\chromedriver.exe",
                $"{zipPath.Replace("chromedriver.zip", "")}chromedriver.exe");
            DeleteFile($"{zipPath.Replace("chromedriver.zip", "")}chromedriver\\chromedriver.exe");
            DeleteFile($"{zipPath.Replace("chromedriver.zip", "")}chromedriver\\LICENSE.chromedriver");
        }
    }
}
