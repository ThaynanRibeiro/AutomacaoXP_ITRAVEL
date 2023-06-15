using Projeto;

public class Program
{
    public static void Main(string[] args)
    {
        ChromeOptionsGeral.AtualizaChromeDriver(); // Atualiza o chromeDriver pra versão mais atual referente ao chrome instalado na máquina
        Xp.XpInvestimentos(); // Inicia bot
    }
}