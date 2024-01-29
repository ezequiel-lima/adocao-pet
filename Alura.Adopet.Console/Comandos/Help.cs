using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações de ajuda.")]
    public class Help : ICommand
    {
        private Dictionary<string, DocComando> _docs;

        public Help()
        {
            _docs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetCustomAttributes<DocComando>().Any())
                .Select(x => x.GetCustomAttribute<DocComando>()!).ToDictionary(x => x.Instrucao);
        }

        public Task Execute(string[] args)
        {
            ExibeDocumentacao(args);
            return Task.CompletedTask;
        }

        private void ExibeDocumentacao(string[] parametros)
        {
            System.Console.WriteLine("Lista de comandos.");

            if (parametros.Length == 1)
            {
                AllCommands();
            }
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];
                if (comandoASerExibido.Equals("import"))
                {
                    Import();
                }
                if (comandoASerExibido.Equals("show"))
                {
                    Show();
                }
            }
        }

        private void AllCommands()
        {
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                     "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");

            foreach (var item in _docs.Values)
            {
                System.Console.WriteLine(item.Documentacao);
            }
            //System.Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
            //System.Console.WriteLine($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
            System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");
        }

        private void Import()
        {
            System.Console.WriteLine(" adopet import <arquivo> " +
                        "comando que realiza a importação do arquivo de pets.");
        }

        private void Show()
        {
            System.Console.WriteLine(" adopet show <arquivo>  comando que " +
                        "exibe no terminal o conteúdo do arquivo importado.");
        }
    }
}
