﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Players;
using Domain.Users;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        public readonly PlayersService _playersService;
        public readonly UsersService _usersService;
        public PlayersController()
        {
            _playersService = new PlayersService();
            _usersService = new UsersService();
        }
        
        [HttpPost]
        public IActionResult Post(CreatePlayerRequest request)
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

            var response = _playersService.Create(request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Id);
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _playersService.GetAll();
        }
    }
}