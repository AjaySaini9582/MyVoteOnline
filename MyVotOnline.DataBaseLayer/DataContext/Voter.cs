using System;
using System.Collections.Generic;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class Voter
{
    public int VoterId { get; set; }

    public string FullName { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? Email { get; set; }

    public int? StateId { get; set; }

    public int? DistrictId { get; set; }

    public int? CityId { get; set; }

    public int? WardId { get; set; }

    public int BoothNo { get; set; }

    public int ParliamentaryNo { get; set; }

    public int Age { get; set; }

    public DateOnly Dob { get; set; }

    public string AadharNo { get; set; } = null!;

    public string? FamilyIdno { get; set; }

    public int? ReligionId { get; set; }

    public int? CasteId { get; set; }

    public int? GenderId { get; set; }

    public int AssemblyNumber { get; set; }

    public int PartNo { get; set; }

    public string EpicNo { get; set; } = null!;

    public string? RationCardNo { get; set; }

    public string FatherName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Caste? Caste { get; set; }

    public virtual City? City { get; set; }

    public virtual District? District { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Religion? Religion { get; set; }

    public virtual State? State { get; set; }

    public virtual Ward? Ward { get; set; }
}
