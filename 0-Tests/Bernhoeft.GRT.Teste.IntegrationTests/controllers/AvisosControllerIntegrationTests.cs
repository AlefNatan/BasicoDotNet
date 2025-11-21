using Xunit;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit.Priority;

namespace Bernhoeft.GRT.Teste.IntegrationTests.Controllers
{
    public class AvisosControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AvisosControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task Post_Aviso_ComDadosValidos_DeveRetornarCreated()
        {
            // Arrange
            var command = new CreateAvisoCommand("Título Teste Integration", "Mensagem Teste Integration");

            // Act
            var response = await _client.PostAsJsonAsync("/api/v1/avisos", command);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var locationHeader = response.Headers.Location;
            locationHeader.Should().NotBeNull();
            locationHeader!.ToString().Should().Contain("/api/v1/avisos/");
        }

        [Fact, Priority(2)]
        public async Task Post_Aviso_ComTituloVazio_DeveRetornarBadRequest()
        {
            // Arrange
            var command = new CreateAvisoCommand("", "Mensagem Teste");

            // Act
            var response = await _client.PostAsJsonAsync("/api/v1/avisos", command);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, Priority(3)]
        public async Task Get_Avisos_DeveRetornarOk()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/avisos");

            // Assert
            response.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        [Fact, Priority(4)]
        public async Task Get_AvisoPorId_ComIdValido_DeveRetornarOk()
        {
            // Arrange
            var avisoId = 1;

            // Act
            var response = await _client.GetAsync($"/api/v1/avisos/{avisoId}");

            // Assert
            response.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NotFound);
        }

        [Fact, Priority(5)]
        public async Task Get_AvisoPorId_ComIdInvalido_DeveRetornarBadRequest()
        {
            // Arrange
            var avisoIdInvalido = 0;

            // Act
            var response = await _client.GetAsync($"/api/v1/avisos/{avisoIdInvalido}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, Priority(6)]
        public async Task Put_Aviso_ComDadosValidos_DeveRetornarOk()
        {
            // Arrange - Primeiro cria um aviso
            var createCommand = new CreateAvisoCommand("Título para Update", "Mensagem Original");
            var createResponse = await _client.PostAsJsonAsync("/api/v1/avisos", createCommand);
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Extrai o ID do location header
            var location = createResponse.Headers.Location?.ToString();
            location.Should().NotBeNull("Location header should not be null for created resource");

            var avisoId = int.Parse(location!.Split('/').Last());

            // Act - Atualiza o aviso
            var updateRequest = new { Mensagem = "Mensagem Atualizada" };
            var updateResponse = await _client.PutAsJsonAsync($"/api/v1/avisos/{avisoId}", updateRequest);

            // Assert
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, Priority(7)]
        public async Task Put_Aviso_ComMensagemVazia_DeveRetornarBadRequest()
        {
            // Arrange
            var avisoId = 1; 
            var updateRequest = new { Mensagem = "" };

            // Act
            var response = await _client.PutAsJsonAsync($"/api/v1/avisos/{avisoId}", updateRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, Priority(8)]
        public async Task Delete_Aviso_ComIdValido_DeveRetornarOk()
        {
            // Arrange - Primeiro cria um aviso
            var createCommand = new CreateAvisoCommand("Título para Delete", "Mensagem para Delete");
            var createResponse = await _client.PostAsJsonAsync("/api/v1/avisos", createCommand);
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            // Extrai o ID do location header
            var location = createResponse.Headers.Location?.ToString();
            location.Should().NotBeNull("Location header should not be null for created resource");

            var avisoId = int.Parse(location!.Split('/').Last());

            // Act 
            var deleteResponse = await _client.DeleteAsync($"/api/v1/avisos/{avisoId}");

            // Assert
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, Priority(9)]
        public async Task Delete_Aviso_ComIdInvalido_DeveRetornarBadRequest()
        {
            // Arrange
            var avisoIdInvalido = 0;

            // Act
            var response = await _client.DeleteAsync($"/api/v1/avisos/{avisoIdInvalido}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, Priority(10)]
        public async Task Put_Aviso_ComIdInexistente_DeveRetornarNotFound()
        {
            // Arrange
            var avisoIdInexistente = 9999;
            var updateRequest = new { Mensagem = "Mensagem qualquer" };

            // Act
            var response = await _client.PutAsJsonAsync($"/api/v1/avisos/{avisoIdInexistente}", updateRequest);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact, Priority(11)]
        public async Task Delete_Aviso_ComIdInexistente_DeveRetornarNotFound()
        {
            // Arrange
            var avisoIdInexistente = 9999;

            // Act
            var response = await _client.DeleteAsync($"/api/v1/avisos/{avisoIdInexistente}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}