using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Voter
{
    public int VoterId { get; set; }

    public int WardId { get; set; }

    public string FullName { get; set; } = null!;

    public int? Age { get; set; }

    public string VoterCardNumber { get; set; } = null!;

    public string? Address { get; set; }

    public virtual Ward Ward { get; set; } = null!;
}
