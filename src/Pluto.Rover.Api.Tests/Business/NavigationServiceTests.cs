using FluentAssertions;
using Pluto.Rover.Api.Business;
using Pluto.Rover.Api.Constants;
using Xunit;

namespace Pluto.Rover.Api.Tests.Business
{
    public class NavigationServiceTests : BaseTests
    {
        private const int ExpectedPosYWhenMoveForward = 1;
        public NavigationServiceTests()
        {
            NavigationService = new NavigationService(PlutoRover);
        }

        [Theory]
        [InlineData(MovingConstants.Forward, CardinalPointConstants.North, PlanetMinPosX, ExpectedPosYWhenMoveForward)]
        [InlineData(MovingConstants.Backward, CardinalPointConstants.North, PlanetMinPosX, PlanetMaxPosY)]
        [InlineData(RotationConstants.Right, CardinalPointConstants.East, PlanetMinPosX, PlanetMinPosY)]
        [InlineData(RotationConstants.Left, CardinalPointConstants.West, PlanetMinPosX, PlanetMinPosY)]
        public async void GivenSingleInstructionWhenRoverIsInStartPositionShouldMoveOrRotateAccordingly(char instruction, char facingDirection, int expectedPosX, int expectedPosY)
        {
            //Arrange
            var instructions = instruction.ToString();

            //Act
            var result = await NavigationService.MoveRover(instructions);

            //Assert
            result.FacingDirection.CardinalPoint.Should().Be(facingDirection);
            result.RoverPosition.PosX.Should().Be(expectedPosX);
            result.RoverPosition.PosY.Should().Be(expectedPosY);
        }

        [Theory]
        [InlineData("FBRL", CardinalPointConstants.North, PlanetMinPosX, PlanetMinPosY)]
        [InlineData("FFRFF", CardinalPointConstants.East, 2, 2)]
        [InlineData("FFLFF", CardinalPointConstants.West, 9, 2)]
        public async void GivenComposedInstructionWhenRoverIsInStartPositionShouldMoveOrRotateAccordingly(string instructions, char facingDirection, int expectedPosX, int expectedPosY)
        {
            //Act
            var result = await NavigationService.MoveRover(instructions);

            //Assert
            result.FacingDirection.CardinalPoint.Should().Be(facingDirection);
            result.RoverPosition.PosX.Should().Be(expectedPosX);
            result.RoverPosition.PosY.Should().Be(expectedPosY);
        }
    }
}