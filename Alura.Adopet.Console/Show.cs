using System;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "show", documentacao: "adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show
    {
        public void ExibeConteudoArquivo(string[] parametros)
        {
            string caminhoDoArquivoASerExibido = parametros[1];
            LeitorDeArquivo leitorDeArquivo = new LeitorDeArquivo();
            var listaDePets = leitorDeArquivo.RealizaLeitura(caminhoDoArquivoASerExibido); 

            foreach (var item in listaDePets)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
