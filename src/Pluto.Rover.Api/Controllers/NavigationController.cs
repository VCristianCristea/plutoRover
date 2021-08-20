using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Pluto.Rover.Api.Constants;
using Pluto.Rover.Api.Exceptions;
using Pluto.Rover.Api.Interfaces;
using Pluto.Rover.Api.Models;

namespace Pluto.Rover.Api.Controllers
{
    [ApiController]
    [Route("v1/api/rover")]
    public class NavigationController : ControllerBase
    {
        private readonly INavigationService navigationService;
        private readonly IList<char> acceptedMoves = new List<char>
        {
            MovingConstants.Forward,
            MovingConstants.Backward,
            RotationConstants.Left,
            RotationConstants.Right
        };

        public NavigationController(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        [HttpPut("move")]
        public async Task<ActionResult> MoveRover(NavigationRequest requestModel)
        {
            if (requestModel.Instructions.Any(instruction => !acceptedMoves.Contains(instruction)))
            {
                throw new BadRequestException(ErrorMessages.InvalidInput);
            }

            var result = await navigationService.MoveRover(requestModel.Instructions);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> RoverInfo()
        {
            return Ok(await navigationService.GetRoverInformation());
        }
    }
}
