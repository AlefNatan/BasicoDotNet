using Xunit;
using FluentAssertions;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

namespace Bernhoeft.GRT.UnitTests.Application.Requests
{
    public class UpdateAvisoCommandTests
    {
        [Fact]
        public void Construtor_ComParametrosValidos_DeveCriarComandoCorretamente()
        {
            // Arrange
            var id = 1;
            var mensagem = "Nova mensagem atualizada";

            // Act
            var command = new UpdateAvisoCommand(id, mensagem);

            // Assert
            command.Id.Should().Be(id);
            command.Mensagem.Should().Be(mensagem);
        }
    }
}