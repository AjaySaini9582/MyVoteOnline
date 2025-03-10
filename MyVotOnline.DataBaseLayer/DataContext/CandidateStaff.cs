using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class CandidateStaff
{
    public int StaffId { get; set; }

    public int? CandidateId { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Candidate? Candidate { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
