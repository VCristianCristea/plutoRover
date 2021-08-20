using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pluto.Rover.Api.Commands.RotateLeft;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Helpers;

namespace Pluto.Rover.Api.Commands.RotateRight
{
    public static class RotateRightHandler
    {
        public static IList<char> CardinalPoints = CardinalPointHelper.GetCardinalPoints();

        public static Task<FacingDirection> RotateRight(FacingDirection facingDirection)
        {
            if (!RotateLeftHandler.CardinalPoints.Contains(facingDirection.CardinalPoint))
                throw new Exception();

            var cardinalPointIndex = CardinalPoints.IndexOf(facingDirection.CardinalPoint);
            if (cardinalPointIndex + 1 > CardinalPoints.Count - 1)
            {
                return Task.FromResult(new FacingDirection
                {
                    CardinalPoint = CardinalPoints.First()
                });
            }

            return Task.FromResult(new FacingDirection
            {
                CardinalPoint = CardinalPoints[cardinalPointIndex + 1]
            });
        }
    }
}