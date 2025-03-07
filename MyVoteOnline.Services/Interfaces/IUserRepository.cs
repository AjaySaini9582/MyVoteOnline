using MyVotOnline.Model;

namespace MyVoteOnline.Services.Interfaces
{
	public interface IUserRepository
	{
		public int AddUser(UserModel user);
	}
}
