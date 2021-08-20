using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.Commands.MoveBackward
{
    public class MoveBackwardCommand : ICommand
    {
        public async Task ExecuteAction(PlutoRover plutoRover)
        {
            plutoRover.RoverPosition = await MoveBackwardHandler.Move(plutoRover);
        }
    }
}