using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;


namespace Projeto
{
    public class Xp
    {
        public static void XpInvestimentos()
        {
            var dr = ChromeOptionsGeral.ChromeOptionsMain(false);

            {
                try
                {
                    dr.Navigate().GoToUrl("https://wtxpreprod5.travelexplorer.com.br/"); // navega para o Zion
                    Thread.Sleep(2000);

                    dr.FindElement(By.Id("txtLogin")).Click(); // clica no campo da Usuario
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("txtLogin")).SendKeys("suporte@itravel.com.br"); // digita o login do usuario
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl00_Login_1_txtPassword")).Click(); // clica no campo da Senha
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl00_Login_1_txtPassword")).SendKeys("#ITravel2020"); // digita a senha
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl00_Login_1_btnLogin")).Click(); // clica no botão "Continuar"
                    Thread.Sleep(1000);

                    try // Verificar se uma mensagem de erro no Login é exibida
                    {
                        IWebElement mensagemErro = dr.FindElement(By.Id("p_lt_ctl00_Login_1_divMsg"));
                        Console.WriteLine("Dados Inválidos!");
                        dr.Quit();

                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine("Login bem-sucedido!");
                    }

                    dr.FindElement(By.Id("tabFlight")).Click(); // Seleciona pesquisa de voo
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtDeparture_txtDescription")).Click(); // Seleciona o campo de Origem
                    Thread.Sleep(2000);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtDeparture_txtDescription")).SendKeys("SAO"); // digita a Origem
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("ac_even")).Click(); // seleciona a origem

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtArrival_txtDescription")).Click(); // Seleciona o campo "Destino"
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtArrival_txtDescription")).SendKeys("RIO"); // digita o destino
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/div[3]/ul/li[1]")).Click(); // seleciona o destino
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("p_lt_ctl02_pageplaceholder_p_lt_ctl01_FSXBuscador_txtDepartureDateAero")).Click(); // Abre o calendário de Chekin
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendario
                    dr.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/div[2]/div/a")).Click(); // Avança o calendario

                    dr.FindElement(By.XPath("/html/body/div[1]/div[2]/table/tbody/tr[3]/td[5]/a")).Click(); // Seleciona a data
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/div[1]/div[1]/table/tbody/tr[3]/td[7]/a")).Click(); // Seleciona data de volta
                    Thread.Sleep(500);

                    dr.FindElement(By.Id("btnSearchFSX")).Click(); // Clica em "Pesquisar"
                    Thread.Sleep(500);

                    int tentativas = 0;
                    bool elementoPresente = false;

                    while (tentativas < 120)
                    {
                        try
                        {
                            IWebElement element = dr.FindElement(By.Id("Group_0"));
                            elementoPresente = true;
                            break;
                        }
                        catch (NoSuchElementException)
                        {
                            Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                            tentativas++;
                        }
                    }

                    if (elementoPresente)
                    {
                        Console.WriteLine("Elemento encontrado!"); // O elemento está presente na página
                    }
                    else
                    {
                        Console.WriteLine("Elemento não encontrado após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                    }

                    dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div[3]/div[3]/div[2]/div[4]/div[1]/div/div[1]/div[1]/div[2]/div[1]/span[1]/span/input")).Click();
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("/html/body/form/main/div[4]/section/div/div/div[3]/div[3]/div[2]/div[4]/div[1]/div/div[1]/div[2]/div[2]/div[1]/span[1]/span/input")).Click();
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("add-flight-cart")).Click();
                    Thread.Sleep(5000);

                    dr.FindElement(By.XPath("//*[@id=\"p_lt_tpMainTag\"]/div[3]/div/div[2]/div[2]/a[2]")).Click();
                    Thread.Sleep(500);

                    while (tentativas < 120)
                    {
                        try
                        {
                            IWebElement element = dr.FindElement(By.Id("btBuy"));
                            elementoPresente = true;
                            break;
                        }
                        catch (NoSuchElementException)
                        {
                            Thread.Sleep(1000); // Elemento não encontrado, aguarde 1 segundo e tente novamente
                            tentativas++;
                        }
                    }

                    if (elementoPresente)
                    {
                        Console.WriteLine("Elemento encontrado!"); // O elemento está presente na página
                    }
                    else
                    {
                        Console.WriteLine("Elemento não encontrado após 120 tentativas."); // O elemento não foi encontrado após as tentativas máximas
                    }

                    dr.FindElement(By.Id("btBuy")).Click(); // Clica no botão "Comprar"
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("firstName")).SendKeys("THAYNAN"); // Insere o nome
                    Thread.Sleep(500);
                    
                    dr.FindElement(By.ClassName("lastName")).SendKeys("RIBEIRO"); // Insere o sobrenome
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("genre")).Click(); // Seleciona campo para inserir o genero
                    Thread.Sleep(500);

                    dr.FindElement(By.XPath("//*[@id=\"contentData\"]/div[1]/div[1]/div[3]/div/span[5]/select/option[2]")).Click(); // Seleciona o sexo M
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("date")).Click(); // Seleciona campo da data de nascimento
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("date")).SendKeys("28092000"); // Insere a data de nascimento
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("document1")).Click(); // Seleciona campo do CPF
                    Thread.Sleep(500);

                    dr.FindElement(By.ClassName("document1")).SendKeys("513.060.560-80"); // Insere o CPF
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // deixa registrado no console o erro que ocorreu
                }

            }
        }
    }
}
