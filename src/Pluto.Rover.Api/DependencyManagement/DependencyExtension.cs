using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pluto.Rover.Api.Business;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.DependencyManagement
{
    public static class DependencyExtension
    {
        public static void RegisterPlanetAndRover(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(InitializePlanet(configuration));

            services.AddSingleton(new PlutoRover
            {
                FacingDirection = new FacingDirection
                {
                    CardinalPoint = configuration["Rover:FacingDirection"].ToCharArray().FirstOrDefault()
                },
                RoverPosition = new Position
                {
                    PosX = int.Parse(configuration["Rover:InitialPosX"]),
                    PosY = int.Parse(configuration["Rover:InitialPosY"])
                }
            });
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<INavigationService, NavigationService>();
        }

        private static Planet InitializePlanet(IConfiguration configuration)
        {
            var maxPosX = int.Parse(configuration["Planet:MaxPosX"]);
            var maxPosY = int.Parse(configuration["Planet:MaxPosY"]);

            var name = configuration["Planet:Name"];

            var numberOfObstacles = int.Parse(configuration["Planet:NumberOfObstacles"]);

            var obstacles = GenerateRandomObstacles(numberOfObstacles);

            return new Planet(name, maxPosX, maxPosY, obstacles);
        }

        private static List<Obstacle> GenerateRandomObstacles(int numberOfObstacles)
        {
            var random = new Random();
            var obstacles = new List<Obstacle>();

            for (var index = 0; index < numberOfObstacles; index++)
            {
                obstacles.Add(new Obstacle
                {
                    Position = new Position
                    {
                        //change 0 to planetMinPos
                        PosX = random.Next(0, Planet.MaxPosX),
                        PosY = random.Next(0, Planet.MaxPosY)
                    }
                });
            }

            return obstacles;
        }

    }
}