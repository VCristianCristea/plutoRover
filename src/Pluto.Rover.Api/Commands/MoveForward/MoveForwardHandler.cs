using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Entities;

namespace Pluto.Rover.Api.Commands.MoveForward
{
    public static class MoveForwardHandler
    {
        private static readonly IDictionary<char, Func<Position, Task<Position>>> MoveForwardFunctions =
            new Dictionary<char, Func<Position, Task<Position>>>
            {
                {CardinalPointConstants.West, PositionHandler.DecreasePosX},
                {CardinalPointConstants.North, PositionHandler.IncrementPosY},
                {CardinalPointConstants.East, PositionHandler.IncrementPosX},
                {CardinalPointConstants.South, PositionHandler.DecreasePosY}
            };

        public static async Task<Position> Move(PlutoRover rover)
        {
            if (!MoveForwardFunctions.ContainsKey(rover.FacingDirection.CardinalPoint))
            {
                throw new Exception();
            }

            return await MoveForwardFunctions[rover.FacingDirection.CardinalPoint](rover.RoverPosition);
        }
    }
}