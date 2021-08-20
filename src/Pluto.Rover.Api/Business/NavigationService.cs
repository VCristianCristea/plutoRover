using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pluto.Rover.Api.Entities;
using Pluto.Rover.Api.Helpers;
using Pluto.Rover.Api.Interfaces;

namespace Pluto.Rover.Api.Business
{
    public class NavigationService : INavigationService
    {
        private readonly IReadOnlyDictionary<char, ICommand> commands = CommandHelper.GetCommands();
        private readonly PlutoRover plutoRover;

        public NavigationService(PlutoRover plutoRover)
        {
            this.plutoRover = plutoRover;
        }

        public async Task<PlutoRover> MoveRover(string instructions)
        {
            foreach (var command in instructions.Select(instruction => commands[instruction]))
            {
                await command.ExecuteAction(plutoRover);
            }

            return plutoRover;
        }

        public Task<PlutoRover> GetRoverInformation()
        {
            return Task.FromResult(plutoRover);
        }
    }
}
