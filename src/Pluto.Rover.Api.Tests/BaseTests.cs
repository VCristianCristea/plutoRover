using System.Collections.Generic;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Controllers;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.Tests
{
    public class BaseTests
    {
        protected const int OkStatusCode = 200;
        protected const string InvalidInstruction = "MM";
        protected const char InvalidCardinalPoint = 'M';
        protected const int RoverFacingObstaclesPosX = 5;
        protected const int RoverFacingObstaclesPosY = 5;
        protected const int PlanetMaxPosX = 10;
        protected const int PlanetMaxPosY = 10;
        protected const int PlanetMinPosX = 0;
        protected const int PlanetMinPosY = 0;

        protected NavigationController Controller;
        protected INavigationService NavigationService;

        protected PlutoRover PlutoRover = new PlutoRover
        {
            FacingDirection = new FacingDirection {CardinalPoint = CardinalPointConstants.North},
            RoverPosition = new Position
            {
                PosX = 0,
                PosY = 0
            }
        };
        
        protected Position RoverPositionFacingObstacle = new Position
        {
            PosX = RoverFacingObstaclesPosX,
            PosY = RoverFacingObstaclesPosX
        };

        protected Planet TestPlanet = new Planet("TestPlanet", PlanetMaxPosX, PlanetMaxPosY, Obstacles);

        private static readonly List<Obstacle> Obstacles = new List<Obstacle>
        {
            new Obstacle
            {
                Position = new Position
                {
                    PosX = RoverFacingObstaclesPosX + 1,
                    PosY = 5
                }
            },
            new Obstacle
            {
                Position = new Position
                {
                    PosX = 5,
                    PosY = RoverFacingObstaclesPosY + 1
                }
            },
            new Obstacle
            {
                Position = new Position
                {
                    PosX = RoverFacingObstaclesPosX - 1,
                    PosY = 5
                }
            },
            new Obstacle
            {
                Position = new Position
                {
                    PosX = 5,
                    PosY = RoverFacingObstaclesPosY - 1
                }
            }
        };
    }
}