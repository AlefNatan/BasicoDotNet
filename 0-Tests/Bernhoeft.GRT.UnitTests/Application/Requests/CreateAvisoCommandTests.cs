using Xunit;
using FluentAssertions;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

namespace Bernhoeft.GRT.UnitTests.Application.Requests
{
    public class CreateAvisoCommandTests
    {
        [Fact]
        public void Construtor_ComParametrosValidos_DeveCriarComandoCorretamente()
        {
            // Arrange
            var titulo = "Título Teste";
            var mensagem = "Mensagem Teste";

            // Act
            var command = new CreateAvisoCommand(titulo, mensagem);

            // Assert
            command.Titulo.Should().Be(titulo);
            command.Mensagem.Should().Be(mensagem);
        }
    }
}