using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Caste
{
    public int CasteId { get; set; }

    public string? CasteName { get; set; }

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();
}
