using Microsoft.EntityFrameworkCore;
using MyVoteOnline.Services.Interfaces;
using MyVoteOnline.Services.Utilty;
using MyVotOnline.DataBaseLayer.DataContext;
using MyVotOnline.Model;

namespace MyVoteOnline.Services.Repositories
{
	public class UserRepository(VoteContext context) : IUserRepository
	{
		private readonly VoteContext _context = context;

		public async Task<int> AddUser(UserModel user)
		{
			int userId = 0;
			using (var transaction = _context.Database.BeginTransaction())
			{

				try
				{
					var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
					if (existingUser != null)
					{
						throw new Exception("Email is already Registered");
					}
					if (string.IsNullOrEmpty(user.PasswordHash))
					{
						throw new ArgumentNullException("Password cannot be Empty");
					}
					User newUser = new User
					{
						FullName = user.FullName,
						Email = user.Email,
						PasswordHash = PasswordHelper.HashPassword(user.PasswordHash),
						RoleId = user.RoleId,
						MobileNo = user.MobileNo,
						CreatedAt = DateTime.UtcNow
					};
					_context.Users.Add(newUser);
					_context.Entry(newUser).State = EntityState.Added;
					await _context.SaveChangesAsync();
					userId = newUser.UserId;
					await transaction.CommitAsync();
				}
				catch
				{
					await transaction.RollbackAsync(); // Non-blocking
					throw;
				}
			}
			return userId;
		}
	}
}
