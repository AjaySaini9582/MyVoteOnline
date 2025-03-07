using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class ChangeRequest
{
    public int RequestId { get; set; }

    public int CandidateId { get; set; }

    public string FieldName { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string? Status { get; set; }

    public DateTime? RequestedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;
}
