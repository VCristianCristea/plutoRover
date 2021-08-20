using System;

namespace Pluto.Rover.Api.Exceptions
{
    public class ObstacleHitException : Exception
    {
        public ObstacleHitException()
        {
        }

        public ObstacleHitException(string message)
            : base(message)
        {
        }
    }
}