using System.Collections.Generic;
using Pluto.Rover.Api.Commands;
using Pluto.Rover.Api.Commands.MoveBackward;
using Pluto.Rover.Api.Commands.MoveForward;
using Pluto.Rover.Api.Commands.RotateLeft;
using Pluto.Rover.Api.Commands.RotateRight;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.Helpers
{
    public static class CommandHelper
    {
        private static readonly IReadOnlyDictionary<char, ICommand> AggregatedCommands = new Dictionary<char, ICommand>
        {
            {MovingConstants.Forward, new MoveForwardCommand()},
            {MovingConstants.Backward, new MoveBackwardCommand()},
            {RotationConstants.Left, new RotateLeftCommand()},
            {RotationConstants.Right, new RotateRightCommand()}
        };

        public static IReadOnlyDictionary<char, ICommand> GetCommands()
        {
            return AggregatedCommands;
        }
    }
}