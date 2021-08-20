using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Entities;

namespace Pluto.Rover.Api.Commands.MoveBackward
{
    public static class MoveBackwardHandler 
    {
        public static IDictionary<char, Func<Position, Task<Position>>> MoveBackwardFunctions =
            new Dictionary<char, Func<Position, Task<Position>>>
            {
                {CardinalPointConstants.West, PositionHandler.IncrementPosX},
                {CardinalPointConstants.North, PositionHandler.DecreasePosY},
                {CardinalPointConstants.East, PositionHandler.DecreasePosX},
                {CardinalPointConstants.South, PositionHandler.IncrementPosY}
            };

        public static async Task<Position> Move(PlutoRover rover)
        {
            if (!MoveBackwardFunctions.ContainsKey(rover.FacingDirection.CardinalPoint))
            {
                throw new Exception();
            }

            return await MoveBackwardFunctions[rover.FacingDirection.CardinalPoint](rover.RoverPosition);
        }
    }
}