using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class State
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();
}
