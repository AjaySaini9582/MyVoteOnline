namespace MyVotOnline.Model
{
	public class VoterModel
	{
		public int VoterId { get; set; }

		public int WardId { get; set; }

		public string FullName { get; set; } = null!;

		public int? Age { get; set; }

		public string VoterCardNumber { get; set; } = null!;

		public string? Address { get; set; }

	}
}
