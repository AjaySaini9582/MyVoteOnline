namespace MyVotOnline.Model
{
	public class CandidateModel
	{
		public int CandidateId { get; set; }

		public int UserId { get; set; }

		public int WardId { get; set; }

		public string PartyName { get; set; } = null!;

		public string? ElectionSymbol { get; set; }
	}
}
