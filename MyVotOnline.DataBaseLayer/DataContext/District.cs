using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class District
{
    public int DistrictId { get; set; }

    public string? DistrictName { get; set; }

    public int? StateId { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual State? State { get; set; }

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();
}
