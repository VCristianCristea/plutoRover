using System.Collections.Generic;

namespace Pluto.Rover.Api.Entities
{
    public class Planet
    {
        public Planet(string name, int maxPosX, int maxPosY, IReadOnlyList<Obstacle> obstacles)
        {
            Name = name;
            MaxPosX = maxPosX;
            MaxPosY = maxPosY;
            Obstacles = obstacles;
        }

        public static IReadOnlyList<Obstacle> Obstacles { get; private set; } = new List<Obstacle>();
        public static string Name { get; private set; }
        public static int MaxPosX { get; private set; }
        public static int MaxPosY { get; private set; }
    }
}