using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Gender
{
    public int GenderId { get; set; }

    public string? GenderName { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();
}
