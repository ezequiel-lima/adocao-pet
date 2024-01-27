namespace Alura.Adopet.Console
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocComando : Attribute
    {
        public DocComando(string instrucao, string documentacao)
        {
            Instrucao = instrucao;
            Documentacao = documentacao;
        }

        public string Instrucao { get; set; }
        public string Documentacao { get; set; }
    }
}
