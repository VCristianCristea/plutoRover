using System.Collections.Generic;
using Pluto.Rover.Api.Constants;

namespace Pluto.Rover.Api.Helpers
{
    public static class CardinalPointHelper
    {
        private static readonly IList<char> CardinalPoints = new List<char>
        {
            CardinalPointConstants.West,
            CardinalPointConstants.North,
            CardinalPointConstants.East,
            CardinalPointConstants.South
        };

        public static IList<char> GetCardinalPoints()
        {
            return CardinalPoints;
        }
    }
}