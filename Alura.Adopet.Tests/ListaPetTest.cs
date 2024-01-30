using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Tests
{
    public class ListaPetTest
    {
        [Fact]
        public async Task Deve_Retornar_Lista_De_Pets()
        {
            // Arrange
            var list = new ListaPet();

            // Act
            await list.ListPetsAsync();

            //Assert
            Assert.NotNull(list);
        }
    }
}