using Xunit;
using FluentAssertions;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

namespace Bernhoeft.GRT.UnitTests.Application.Requests
{
    public class DeleteAvisoCommandTests
    {
        [Fact]
        public void Construtor_ComParametrosValidos_DeveCriarComandoCorretamente()
        {
            // Arrange
            var id = 1;

            // Act
            var command = new DeleteAvisoCommand(id);

            // Assert
            command.Id.Should().Be(id);
        }
    }
}