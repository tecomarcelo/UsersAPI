using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Tests.Helpers;
using Xunit;

namespace UsersAPI.Tests
{
    public class UsersTests
    {
        [Fact]
        public async Task Users_Post_Returns_Created()
        {
            //dados enviados para a requisição
            var faker = new Faker("pt_BR");
            var request = new UserAddRequestDto
            {
                Name = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Password = "@Teste123",
                PasswordConfirm = "@Teste123"
            };

            //serializando os dados da requisição
            var content = TestHelper.CreateContent(request);

            //fazendo a requisição POST para a API
            var result = await TestHelper.CreateClient.PostAsync("/api/users", content);

            //capturando e verificando o status de resposta
            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            //capturando e verificando o conteudo da resposta
            var response = TestHelper.ReadResponse<UserResponseDto>(result);
            response.Id.Should().NotBeEmpty();
            response.Name.Should().Be(request.Name);
            response.Email.Should().Be(request.Email);
            response.CreatedAt.Should().NotBeNull();
        }

        [Fact(Skip = "Não implementado.")]
        public void Users_Post_Returns_BadRequest()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado.")]
        public void Users_Put_Returns_Ok()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado.")]
        public void Users_Delete_Returns_Ok()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado.")]
        public void Users_Get_Returns_Ok()
        {
            //TODO
        }
    }
}
