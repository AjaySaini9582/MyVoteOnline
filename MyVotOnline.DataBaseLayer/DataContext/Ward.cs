﻿using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Ward
{
    public int WardId { get; set; }

    public int? WardNumber { get; set; }

    public int? CityId { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual City? City { get; set; }

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();
}
