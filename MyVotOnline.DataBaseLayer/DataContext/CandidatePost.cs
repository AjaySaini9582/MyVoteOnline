using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class CandidatePost
{
    public int PostId { get; set; }

    public int? CandidateId { get; set; }

    public int? CreatedBy { get; set; }

    public string? PostTitle { get; set; }

    public string? PostContent { get; set; }

    public string? PostImage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Candidate? Candidate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }
}
