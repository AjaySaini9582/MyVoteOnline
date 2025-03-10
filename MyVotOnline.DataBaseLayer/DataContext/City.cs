using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? DistrictId { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual District? District { get; set; }

    public virtual ICollection<Voter> Voters { get; set; } = new List<Voter>();

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
