using FluentAssertions;
using Xunit;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations;

namespace Bernhoeft.GRT.UnitTests.Application.Validators
{
    public class GetAvisoRequestValidatorTests
    {
        private readonly GetAvisoRequestValidation _validator;

        public GetAvisoRequestValidatorTests()
        {
            _validator = new GetAvisoRequestValidation();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void Validar_ComIdValido_DevePassarNaValidacao(int idValido)
        {
            // Arrange
            var request = new GetAvisoRequest(idValido);

            // Act
            var result = _validator.Validate(request);

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
            var request = new GetAvisoRequest(idInvalido);

            // Act
            var result = _validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Id");
        }
    }
}