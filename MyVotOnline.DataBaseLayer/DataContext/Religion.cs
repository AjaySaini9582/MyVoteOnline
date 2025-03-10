using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Religion
{
    public int ReligionId { get; set; }

    public string? ReligionName { get; set; }

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();
}
