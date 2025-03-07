namespace MyVotOnline.Model
{
	public class UserModel
	{
		public int UserId { get; set; }

		public string FullName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string PasswordHash { get; set; } = null!;

		public int RoleId { get; set; }

		public int? WardId { get; set; }

		public DateTime? CreatedAt { get; set; }
	}
}
