using System.Net.Http.Headers;
using Alura.Adopet.Console;

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comando = args[0].Trim();
    switch (comando)
    {
        case "import":
            var import = new Import();
            await import.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
            break;
        case "help":
            var help = new Help();
            help.ExibeDocumentacao(args);
            break;
        case "show":
            var show = new Show();
            show.ExibeConteudoArquivo(args);           
            break;
        case "list":
            var list = new List();
            await list.PetsAsync();          
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
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