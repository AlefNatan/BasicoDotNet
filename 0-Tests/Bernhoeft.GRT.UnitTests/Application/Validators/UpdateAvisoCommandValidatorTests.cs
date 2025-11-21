using FluentAssertions;
using Xunit;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

namespace Bernhoeft.GRT.UnitTests.Application.Validators
{
    public class UpdateAvisoCommandValidatorTests
    {
        private readonly UpdateAvisoCommandValidation _validator;

        public UpdateAvisoCommandValidatorTests()
        {
            _validator = new UpdateAvisoCommandValidation();
        }

        [Fact]
        public void Validar_ComandoValido_DevePassarNaValidacao()
        {
            // Arrange
            var command = new UpdateAvisoCommand(1, "Mensagem válida atualizada");

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validar_ComIdInvalido_DeveRetornarErro(int idInvalido)
        {
            // Arrange
            var command = new UpdateAvisoCommand(idInvalido, "Mensagem válida");

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Id");
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Validar_ComMensagemInvalida_DeveRetornarErro(string mensagemInvalida)
        {
            // Arrange
            var command = new UpdateAvisoCommand(1, mensagemInvalida);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Mensagem");
        }

        [Fact]
        public void Validar_ComMensagemNull_DeveRetornarErro()
        {
            // Arrange
            var command = new UpdateAvisoCommand(1, null!); 

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Mensagem");
        }
    }
}