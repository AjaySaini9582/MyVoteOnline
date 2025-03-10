using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<CandidateStaff> CandidateStaffs { get; set; } = new List<CandidateStaff>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
