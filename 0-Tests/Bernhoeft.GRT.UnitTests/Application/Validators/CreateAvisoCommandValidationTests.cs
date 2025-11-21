using FluentAssertions;
using Xunit;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

namespace Bernhoeft.GRT.UnitTests.Application.Validators
{
    public class CreateAvisoCommandValidationTests
    {
        private readonly CreateAvisoCommandValidation _validator;

        public CreateAvisoCommandValidationTests()
        {
            _validator = new CreateAvisoCommandValidation();
        }

        [Fact]
        public void Validar_ComandoValido_DevePassarNaValidacao()
        {
            // Arrange
            var command = new CreateAvisoCommand("Título válido", "Mensagem válida");

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validar_QuandoTituloVazio_DeveRetornarErro()
        {
            // Arrange
            var command = new CreateAvisoCommand("", "Mensagem válida");

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Titulo");
        }

        [Fact]
        public void Validar_QuandoMensagemVazia_DeveRetornarErro()
        {
            // Arrange
            var command = new CreateAvisoCommand("Título válido", "");

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Mensagem");
        }
    }
}