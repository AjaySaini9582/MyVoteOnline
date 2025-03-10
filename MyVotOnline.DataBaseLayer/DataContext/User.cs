using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? ConfirmPassword { get; set; }

    public string? MobileNo { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CandidatePost> CandidatePosts { get; set; } = new List<CandidatePost>();

    public virtual ICollection<CandidateStaff> CandidateStaffs { get; set; } = new List<CandidateStaff>();

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual Role? Role { get; set; }
}
