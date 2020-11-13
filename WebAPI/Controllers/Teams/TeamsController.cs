using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Players;
using Domain.Users;
using Domain.Teams;

namespace WebAPI.Controllers.Teams
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        public readonly TeamsService _teamsService;
        public readonly UsersService _usersService;
        public TeamsController()
        {
            _teamsService = new TeamsService();
            _usersService = new UsersService();
        }
        
        [HttpPost]
        public IActionResult Post(CreateTeamRequest request)
        {
            var foundId = Request.Headers.TryGetValue("UserId", out var headerId);
            if (!foundId) { return Unauthorized("User ID must be informed"); }

            var validId = Guid.TryParse(headerId, out var userId);
            if (!validId) { return Unauthorized("Invalid ID"); }
            
            var user = _usersService.GetByID(userId);

            if (user == null)
            {
                return Unauthorized("User does not exist");
            }
            
            if (user.Profile != Profile.CBF)
            {
                return StatusCode(403, "User is not CBF");
            }

            var response = _teamsService.Create(request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Id);
        }

        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return _teamsService.GetAll();
        }
    }
}
