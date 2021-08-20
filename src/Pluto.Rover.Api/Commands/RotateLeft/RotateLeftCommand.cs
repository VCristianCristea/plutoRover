using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.Commands.RotateLeft
{
    public class RotateLeftCommand : ICommand
    {
        public async Task ExecuteAction(PlutoRover plutoRover)
        {
            plutoRover.FacingDirection = await RotateLeftHandler.RotateLeft(plutoRover.FacingDirection);
        }
    }
}