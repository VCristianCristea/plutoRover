using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.Commands.MoveForward
{
    public class MoveForwardCommand : ICommand
    {
        public async Task ExecuteAction(PlutoRover plutoRover)
        {
            plutoRover.RoverPosition = await MoveForwardHandler.Move(plutoRover);
        }
    }
}