using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;

namespace Pluto.Rover.Api.Interfaces
{
    public interface INavigationService
    {
        Task<PlutoRover> MoveRover(string instructions);

        Task<PlutoRover> GetRoverInformation();
    }
}