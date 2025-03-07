using MyVotOnline.Model;

namespace MyVoteOnline.Services.Interfaces
{
	public interface IUserRepository
	{
		Task<int> AddUser(UserModel user);
	}
}
