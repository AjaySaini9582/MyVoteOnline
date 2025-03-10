using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class CandidateProfile
{
    public int ProfileId { get; set; }

    public int? CandidateId { get; set; }

    public string? ProfileImage { get; set; }

    public string? BannerImage { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate? Candidate { get; set; }
}
