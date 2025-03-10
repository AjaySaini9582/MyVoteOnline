using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Candidate
{
    public int CandidateId { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string MobileNumber { get; set; } = null!;

    public int? GenderId { get; set; }

    public string? PartyName { get; set; }

    public int? StateId { get; set; }

    public int? DistrictId { get; set; }

    public int? CityId { get; set; }

    public int? WardId { get; set; }

    public string? InstagramLink { get; set; }

    public string? FacebookUrl { get; set; }

    public string? TwitterUrl { get; set; }

    public string? YoutubeUrl { get; set; }

    public string? LinkedinUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<CandidatePost> CandidatePosts { get; set; } = new List<CandidatePost>();

    public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();

    public virtual ICollection<CandidateStaff> CandidateStaffs { get; set; } = new List<CandidateStaff>();

    public virtual City? City { get; set; }

    public virtual District? District { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual State? State { get; set; }

    public virtual User? User { get; set; }

    public virtual Ward? Ward { get; set; }
}
