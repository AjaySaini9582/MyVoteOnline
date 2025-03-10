namespace MyVotOnline.Model
{
	public class UserModel
	{
		public int UserId { get; set; }

		public string? FullName { get; set; }

		public string? Email { get; set; }

		public string? PasswordHash { get; set; }

		public string? ConfirmPassword { get; set; }

		public string? MobileNo { get; set; }

		public int? RoleId { get; set; }
		public DateTime? CreatedAt { get; set; }

	}
}
