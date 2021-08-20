using System.Linq;
using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Exceptions;

namespace Pluto.Rover.Api.Commands
{
    public class PositionHandler
    {
        private const int PositionIncrement = 1;

        public static Task<Position> IncrementPosX(Position currentPosition)
        {
            if (IsFacingObstacle(currentPosition.PosX + PositionIncrement, currentPosition.PosY))
                throw new ObstacleHitException(
                    $"Obstacle present at position ({currentPosition.PosX + PositionIncrement},{currentPosition.PosY}) " +
                    "in order to find the last possible position make a get request");

            return Task.FromResult(new Position
            {
                PosX = currentPosition.PosX + PositionIncrement > Planet.MaxPosX ? 0 : currentPosition.PosX + PositionIncrement,
                PosY = currentPosition.PosY
            });
        }

        public static Task<Position> IncrementPosY(Position currentPosition)
        {
            if (IsFacingObstacle(currentPosition.PosX, currentPosition.PosY + PositionIncrement))
                throw new ObstacleHitException($"Obstacle present at position ({currentPosition.PosX},{currentPosition.PosY + PositionIncrement}) " +
                                               $"in order to find the last possible position make a get request");

            return Task.FromResult(new Position
            {
                PosX = currentPosition.PosX,
                PosY = currentPosition.PosY + PositionIncrement > Planet.MaxPosY ? 0 : currentPosition.PosY + PositionIncrement
            });
        }

        public static Task<Position> DecreasePosX(Position currentPosition)
        {
            if (IsFacingObstacle(currentPosition.PosX - PositionIncrement, currentPosition.PosY))
                throw new ObstacleHitException($"Obstacle present at position ({currentPosition.PosX - PositionIncrement},{currentPosition.PosY}) " +
                                               $"in order to find the last possible position make a get request");

            return Task.FromResult(new Position
            {
                PosX = currentPosition.PosX - PositionIncrement < 0 ? Planet.MaxPosX : currentPosition.PosX - PositionIncrement,
                PosY = currentPosition.PosY
            });
        }

        public static Task<Position> DecreasePosY(Position currentPosition)
        {
            if (IsFacingObstacle(currentPosition.PosX, currentPosition.PosY - PositionIncrement))
                throw new ObstacleHitException($"Obstacle present at position ({currentPosition.PosX},{currentPosition.PosY - PositionIncrement}) " +
                                               $"in order to find the last possible position make a get request");

            return Task.FromResult(new Position
            {
                PosX = currentPosition.PosX,
                PosY = currentPosition.PosY - PositionIncrement < 0 ? Planet.MaxPosY : currentPosition.PosY - PositionIncrement
            });
        }

        public static bool IsFacingObstacle(int posX, int posY)
        {
            return Planet.Obstacles.Any(obstacle => posX == obstacle.Position.PosX && posY == obstacle.Position.PosY);
        }
    }
}