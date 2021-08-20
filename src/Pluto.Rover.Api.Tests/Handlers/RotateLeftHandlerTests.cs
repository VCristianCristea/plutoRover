using System;
using FluentAssertions;
using Pluto.Rover.Api.Commands.RotateLeft;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Entities;
using Xunit;

namespace Pluto.Rover.Api.Tests.Handlers
{
    public class RotateLeftHandlerTests : BaseTests
    {
        [Theory]
        [InlineData(CardinalPointConstants.West, CardinalPointConstants.South)]
        [InlineData(CardinalPointConstants.North, CardinalPointConstants.West)]
        [InlineData(CardinalPointConstants.East, CardinalPointConstants.North)]
        [InlineData(CardinalPointConstants.South, CardinalPointConstants.East)]
        public async void GivenValidFacingDirectionWhenRotateLeftShouldRotateAccordingly(char cardinalPoint,
            char expectedCardinalPoint)
        {
            //Arrange
            var facingDirection = new FacingDirection
            {
                CardinalPoint = cardinalPoint
            };

            //Act
            var response = await RotateLeftHandler.RotateLeft(facingDirection);

            //Assert
            response.Should().NotBeNull();
            response.CardinalPoint.Should().Be(expectedCardinalPoint);
        }

        [Fact]
        public async void GivenInValidFacingDirectionWhenRotateLeftShouldThrowException()
        {
            //Arrange
            var facingDirection = new FacingDirection
            {
                CardinalPoint = InvalidCardinalPoint
            };

            //Act && Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await RotateLeftHandler.RotateLeft(facingDirection);
            });
        }
    }
}