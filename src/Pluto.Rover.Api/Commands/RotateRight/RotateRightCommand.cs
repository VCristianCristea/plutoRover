using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.Commands.RotateRight
{
    public class RotateRightCommand : ICommand
    {
        public async Task ExecuteAction(PlutoRover plutoRover)
        {
            plutoRover.FacingDirection = await RotateRightHandler.RotateRight(plutoRover.FacingDirection);
        }
    }
}