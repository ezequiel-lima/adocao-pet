namespace Alura.Adopet.Console.Comandos
{
    public interface ICommand
    {
        Task Execute(string[] args);
    }
}
