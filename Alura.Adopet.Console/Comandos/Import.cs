using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class Import : ICommand
    {
        private readonly HttpClient _client;

        public Import()
        {
            _client = ConfiguraHttpClient("http://localhost:5057");
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            LeitorDeArquivo leitorDeArquivo = new LeitorDeArquivo();
            List<Pet> listaDePet = leitorDeArquivo.RealizaLeitura(caminhoDoArquivoDeImportacao);

            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    var resposta = await CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }

        Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return _client.PostAsJsonAsync("pet/add", pet);
            }
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        public async Task Execute(string[] args)
        {
            await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }
    }
}
