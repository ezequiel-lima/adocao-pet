using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console
{
    public class LeitorDeArquivo
    {
        public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
        {
            List<Pet> pets = new List<Pet>();

            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
            {
                System.Console.WriteLine("----- Serão importados os dados abaixo -----");
                while (!sr.EndOfStream)
                {
                    string[] propriedades = sr.ReadLine().Split(';');
                    Pet pet = new Pet(Guid.Parse(propriedades[0]), propriedades[1], TipoPet.Cachorro);
                    pets.Add(pet);
                }

                return pets;
            }
        }
    }
}
