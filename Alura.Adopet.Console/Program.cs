using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;

Console.ForegroundColor = ConsoleColor.Green;
Dictionary<string, ICommand> comandosDoSistema = new Dictionary<string, ICommand>()
{
    { "help", new Help() },
    { "import", new Import() },
    { "list", new ListaPet() },
    { "show", new Show() }
};

try
{
    string comando = args[0].Trim();

    if (comandosDoSistema.ContainsKey(comando))
    {
        ICommand? command = comandosDoSistema[comando];
        await command.Execute(args);
    }
    else
    {
        Console.WriteLine("Comando invalido!");
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}