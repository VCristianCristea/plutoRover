using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;

namespace Pluto.Rover.Api.Interfaces
{
    public interface ICommand
    {
        Task ExecuteAction(PlutoRover plutoRover);
    }
}