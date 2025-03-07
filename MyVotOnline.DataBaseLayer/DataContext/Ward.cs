using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Ward
{
    public int WardId { get; set; }

    public string WardName { get; set; } = null!;

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();
}
