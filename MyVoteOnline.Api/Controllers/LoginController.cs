using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVotOnline.DataBaseLayer.DataContext;
using MyVotOnline.Model;

namespace MyVoteOnline.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController(VoteContext context) : ControllerBase
	{
		private readonly VoteContext _context = context;

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequests request)
		{

			var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.PasswordHash == request.Password);
			if (user == null)
			{
				return Unauthorized(new { message = "Invalid Email or Password" });
			}
			return Ok(new { message = "Successfully" });
		}
	}
}
