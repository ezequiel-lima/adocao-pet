namespace Alura.Adopet.Console
{
    public class Show
    {
        public void ExibeConteudoArquivo(string[] parametros)
        {
            string caminhoDoArquivoASerExibido = parametros[1];
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
            {
                System.Console.WriteLine("----- Serão importados os dados abaixo -----");
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    TipoPet.Cachorro
                    );
                    System.Console.WriteLine(pet);
                }
            }
        }
    }
}
