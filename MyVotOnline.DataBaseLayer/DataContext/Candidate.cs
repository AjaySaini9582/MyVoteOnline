using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Candidate
{
    public int CandidateId { get; set; }

    public int UserId { get; set; }

    public int WardId { get; set; }

    public string PartyName { get; set; } = null!;

    public string? ElectionSymbol { get; set; }

    public virtual ICollection<ChangeRequest> ChangeRequests { get; set; } = new List<ChangeRequest>();

    public virtual User User { get; set; } = null!;

    public virtual Ward Ward { get; set; } = null!;
}
