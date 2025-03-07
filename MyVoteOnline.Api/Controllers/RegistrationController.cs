﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVoteOnline.Services.Interfaces;
using MyVotOnline.Model;

namespace MyVoteOnline.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistrationController(IUserRepository userRepository) : ControllerBase
	{
		private readonly IUserRepository _userRepository = userRepository;

		[HttpPost]
		public IActionResult Post(UserModel user)
		{
			var result = _userRepository.AddUser(user);
			return Ok(new { Status = "success", Result = result });
		}
	}
}
