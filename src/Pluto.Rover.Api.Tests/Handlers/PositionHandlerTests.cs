using FluentAssertions;
using Pluto.Rover.Api.Commands;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Exceptions;
using Xunit;

namespace Pluto.Rover.Api.Tests.Handlers
{
    public class PositionHandlerTests : BaseTests
    {
        [Theory]
        [InlineData(2, 3)]
        [InlineData(PlanetMaxPosX, PlanetMinPosX)]
        public async void GivenCurrentPositionWhenIncrementPosXThenPosXShouldBeIncremented(int posX, int expectedPosX)
        {
            //Arrange
            var currentPosition = new Position
            {
                PosX = posX,
                PosY = 2
            };

            //Act
            var response = await PositionHandler.IncrementPosX(currentPosition);

            //Assert
            response.PosX.Should().Be(expectedPosX);
            response.PosY.Should().Be(currentPosition.PosY);
        }

        [Fact]
        public async void GivenCurrentPositionWhenIncrementPosXAndIsFacingObstacleThenShouldThrowException()
        {
            //Arrange
            var currentPosition = RoverPositionFacingObstacle;

            //Act && Assert
            await Assert.ThrowsAsync<ObstacleHitException>(async () =>
            {
                await PositionHandler.IncrementPosX(currentPosition);
            });
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(PlanetMaxPosY, PlanetMinPosY)]
        public async void GivenCurrentPositionWhenIncrementPosYThenPosYShouldBeIncremented(int posY, int expectedPosY)
        {
            //Arrange
            var currentPosition = new Position
            {
                PosX = 2,
                PosY = posY
            };

            //Act
            var response = await PositionHandler.IncrementPosY(currentPosition);

            //Assert
            response.PosX.Should().Be(currentPosition.PosX);
            response.PosY.Should().Be(expectedPosY);
        }

        [Fact]
        public async void GivenCurrentPositionWhenIncrementPosYAndIsFacingObstacleThenShouldThrowException()
        {
            //Arrange
            var currentPosition = RoverPositionFacingObstacle;

            //Act && Assert
            await Assert.ThrowsAsync<ObstacleHitException>(async () =>
            {
                await PositionHandler.IncrementPosY(currentPosition);
            });
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(PlanetMinPosX, PlanetMaxPosX)]
        public async void GivenCurrentPositionWhenDecreasePostXThenPosYShouldBeDecreased(int posX, int expectedPosX)
        {
            //Arrange
            var currentPosition = new Position
            {
                PosX = posX,
                PosY = 2
            };
            
            //Act
            var response = await PositionHandler.DecreasePosX(currentPosition);

            //Assert
            response.PosX.Should().Be(expectedPosX);
            response.PosY.Should().Be(currentPosition.PosY);
        }

        [Fact]
        public async void GivenCurrentPositionWhenDecrementPosXAndIsFacingObstacleThenShouldThrowException()
        {
            //Arrange
            var currentPosition = RoverPositionFacingObstacle;
                
            //Act && Assert
            await Assert.ThrowsAsync<ObstacleHitException>(async () =>
            {
                await PositionHandler.DecreasePosX(currentPosition);
            });
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(PlanetMinPosY, PlanetMaxPosY)]
        public async void GivenCurrentPositionWhenDecreasePosYThenPosYShouldBeDecreased(int posY, int expectedPosY)
        {
            //Arrange
            var currentPosition = new Position
            {
                PosX = 2,
                PosY = posY
            };

            //Act
            var response = await PositionHandler.DecreasePosY(currentPosition);

            //Assert
            response.PosX.Should().Be(currentPosition.PosX);
            response.PosY.Should().Be(expectedPosY);
        }

        [Fact]
        public async void GivenCurrentPositionWhenDecrementPosYAndIsFacingObstacleThenShouldThrowException()
        {
            //Arrange
            var currentPosition = RoverPositionFacingObstacle;

            //Act && Assert
            await Assert.ThrowsAsync<ObstacleHitException>(async () =>
            {
                await PositionHandler.DecreasePosY(currentPosition);
            });
        }

    }
}