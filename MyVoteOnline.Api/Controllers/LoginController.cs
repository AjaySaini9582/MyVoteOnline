using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVoteOnline.Services.Interfaces;
using MyVotOnline.DataBaseLayer.DataContext;
using MyVotOnline.Model;

namespace MyVoteOnline.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController(ILoginRepository loginRepository) : ControllerBase
	{
	
		private readonly ILoginRepository _loginRepository = loginRepository;

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequests request)
		{

			var result = await _loginRepository.LoginUser(request);
			if (result == false)
				return Unauthorized(new { message = "Invalid Email or Password" });
			return Ok(new { Status = "Success" ,Result="User Login successfully" ,Data=result});
		}
	}
}
