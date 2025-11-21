using FluentAssertions;
using Xunit;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

namespace Bernhoeft.GRT.UnitTests.Application.Validators
{
    public class DeleteAvisoCommandValidatorTests
    {
        private readonly DeleteAvisoCommandValidation _validator;

        public DeleteAvisoCommandValidatorTests()
        {
            _validator = new DeleteAvisoCommandValidation();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void Validar_ComIdValido_DevePassarNaValidacao(int idValido)
        {
            // Arrange
            var command = new DeleteAvisoCommand(idValido);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Validar_ComIdInvalido_DeveRetornarErro(int idInvalido)
        {
            // Arrange
            var command = new DeleteAvisoCommand(idInvalido);

            // Act
            var result = _validator.Validate(command);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Id");
        }
    }
}