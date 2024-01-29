using System;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show", documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : ICommand
    {
        public Task Execute(string[] args)
        {
            ExibeConteudoArquivo(args[1]);
            return Task.CompletedTask;
        }

        private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
        {
            LeitorDeArquivo leitorDeArquivo = new LeitorDeArquivo();
            var listaDePets = leitorDeArquivo.RealizaLeitura(caminhoDoArquivoASerExibido);

            foreach (var item in listaDePets)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
