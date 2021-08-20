using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Controllers;
using Pluto.Rover.Api.Exceptions;
using Pluto.Rover.Api.Interfaces;
using Pluto.Rover.Api.Models;
using Xunit;

namespace Pluto.Rover.Api.Tests.Controllers
{
    public class NavigationControllerTests : BaseTests
    {
        public NavigationControllerTests()
        {
            NavigationService = Substitute.For<INavigationService>();
            Controller = new NavigationController(NavigationService);
        }

        [Fact]
        public async void GivenAValidRequestWhenNavigateMethodIsCalledShouldReturnOk()
        {
            //Arrange
            var requestModel = new NavigationRequest
            {
                Instructions = "FFRFF"
            };
            NavigationService.MoveRover(requestModel.Instructions).Returns(PlutoRover);

            //Act
            var response = await this.Controller.MoveRover(requestModel);

            //Assert
            response.Should().BeOfType<OkObjectResult>();
            var result = response as OkObjectResult;
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(OkStatusCode);
        }

        [Fact]
        public async void GivenAInValidRequestWhenNavigateMethodIsCalledShouldThrowException()
        {
            //Arrange
            var requestModel = new NavigationRequest
            {
                Instructions = InvalidInstruction
            };

            //Act && Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(async () =>
            {
                await this.Controller.MoveRover(requestModel);
            });

            exception.Message.Should().Be(ErrorMessages.InvalidInput);
        }
    }
}