using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Helpers;

namespace Pluto.Rover.Api.Commands.RotateLeft
{
    public static class RotateLeftHandler
    {
        public static IList<char> CardinalPoints = CardinalPointHelper.GetCardinalPoints();

        public static Task<FacingDirection> RotateLeft(FacingDirection facingDirection)
        {
            if (!CardinalPoints.Contains(facingDirection.CardinalPoint))
                throw new Exception();

            var cardinalPointIndex = CardinalPoints.IndexOf(facingDirection.CardinalPoint);
            if (cardinalPointIndex - 1 < 0)
            {
                return Task.FromResult(new FacingDirection
                {
                    CardinalPoint = CardinalPoints.Last()
                });
            }

            return Task.FromResult(new FacingDirection
            {
                CardinalPoint = CardinalPoints[cardinalPointIndex - 1]
            });
        }
    }
}