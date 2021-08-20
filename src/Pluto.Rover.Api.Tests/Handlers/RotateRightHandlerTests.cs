using System;
using FluentAssertions;
using Pluto.Rover.Api.Commands.RotateRight;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Entities;
using Xunit;

namespace Pluto.Rover.Api.Tests.Handlers
{
    public class RotateRightHandlerTests : BaseTests
    {
        [Theory]
        [InlineData(CardinalPointConstants.West, CardinalPointConstants.North)]
        [InlineData(CardinalPointConstants.North, CardinalPointConstants.East)]
        [InlineData(CardinalPointConstants.East, CardinalPointConstants.South)]
        [InlineData(CardinalPointConstants.South, CardinalPointConstants.West)]
        public async void GivenValidFacingDirectionWhenRotateRightShouldRotateAccordingly(char cardinalPoint,
            char expectedCardinalPoint)
        {
            //Arrange
            var facingDirection = new FacingDirection
            {
                CardinalPoint = cardinalPoint
            };

            //Act
            var response = await RotateRightHandler.RotateRight(facingDirection);

            //Assert
            response.Should().NotBeNull();
            response.CardinalPoint.Should().Be(expectedCardinalPoint);
        }

        [Fact]
        public async void GivenInValidFacingDirectionWhenRotateRightShouldThrowException()
        {
            //Arrange
            var facingDirection = new FacingDirection
            {
                CardinalPoint = InvalidCardinalPoint
            };

            //Act && Assert
            await Assert.ThrowsAsync<Exception>(async () =>
            {
                await RotateRightHandler.RotateRight(facingDirection);
            });
        }
    }
}