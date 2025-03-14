using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyVotOnline.DataBaseLayer.DataContext;

public partial class VoteContext : DbContext
{
    public VoteContext()
    {
    }

    public VoteContext(DbContextOptions<VoteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<CandidatePost> CandidatePosts { get; set; }

    public virtual DbSet<CandidateProfile> CandidateProfiles { get; set; }

    public virtual DbSet<CandidateStaff> CandidateStaffs { get; set; }

    public virtual DbSet<Caste> Castes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voter> Voters { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-P974GNKB;Database=VoteDb;User Id=Ajay;Password=1234;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.CandidateId).HasName("PK__Candidat__DF539B9C7580F707");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FacebookUrl)
                .HasMaxLength(255)
                .HasColumnName("FacebookURL");
            entity.Property(e => e.InstagramLink).HasMaxLength(255);
            entity.Property(e => e.LinkedinUrl)
                .HasMaxLength(255)
                .HasColumnName("LinkedinURL");
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PartyName).HasMaxLength(100);
            entity.Property(e => e.TwitterUrl).HasMaxLength(255);
            entity.Property(e => e.YoutubeUrl)
                .HasMaxLength(255)
                .HasColumnName("YoutubeURL");

            entity.HasOne(d => d.City).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Candidate__CityI__52593CB8");

            entity.HasOne(d => d.District).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK__Candidate__Distr__5165187F");

            entity.HasOne(d => d.Gender).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Candidate__Gende__4F7CD00D");

            entity.HasOne(d => d.State).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Candidate__State__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Candidate__UserI__4E88ABD4");

            entity.HasOne(d => d.Ward).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK__Candidate__WardI__534D60F1");
        });

        modelBuilder.Entity<CandidatePost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Candidat__AA12601834B7FC21");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PostImage).HasMaxLength(255);
            entity.Property(e => e.PostTitle).HasMaxLength(255);

            entity.HasOne(d => d.Candidate).WithMany(p => p.CandidatePosts)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK__Candidate__Candi__68487DD7");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.CandidatePosts)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Candidate__Creat__693CA210");
        });

        modelBuilder.Entity<CandidateProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__Candidat__290C88E4FC013176");

            entity.ToTable("CandidateProfile");

            entity.Property(e => e.BannerImage).HasMaxLength(255);
            entity.Property(e => e.ProfileImage).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateProfiles)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK__Candidate__Candi__6477ECF3");
        });

        modelBuilder.Entity<CandidateStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Candidat__96D4AB17288DD16B");

            entity.ToTable("CandidateStaff");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateStaffs)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK__Candidate__Candi__6D0D32F4");

            entity.HasOne(d => d.Role).WithMany(p => p.CandidateStaffs)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Candidate__RoleI__6EF57B66");

            entity.HasOne(d => d.User).WithMany(p => p.CandidateStaffs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Candidate__UserI__6E01572D");
        });

        modelBuilder.Entity<Caste>(entity =>
        {
            entity.HasKey(e => e.CasteId).HasName("PK__Castes__463E23EC3CE6B7C3");

            entity.Property(e => e.CasteName).HasMaxLength(100);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21B7623071274");

            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.District).WithMany(p => p.Cities)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Cities__District__3E52440B");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__District__85FDA4C656DFB18B");

            entity.Property(e => e.DistrictName).HasMaxLength(100);

            entity.HasOne(d => d.State).WithMany(p => p.Districts)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Districts__State__3B75D760");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Genders__4E24E9F75D4B0CFD");

            entity.Property(e => e.GenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.ReligionId).HasName("PK__Religion__D3ADAB6A7F6D4650");

            entity.Property(e => e.ReligionName).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A3365A45A");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__States__C3BA3B3AEBFD5256");

            entity.Property(e => e.StateName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C8B77159F");

            entity.Property(e => e.ConfirmPassword).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Users__RoleId__44FF419A");
        });

        modelBuilder.Entity<Voter>(entity =>
        {
            entity.HasKey(e => e.VoterId).HasName("PK__Voters__12D25BF821F20CB6");

            entity.HasIndex(e => e.AadharNo, "UQ__Voters__40DC83D19EB9633F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Voters__A9D10534CAF6AEBA").IsUnique();

            entity.HasIndex(e => e.EpicNo, "UQ__Voters__AE7D0870A3C27348").IsUnique();

            entity.HasIndex(e => e.RationCardNo, "UQ__Voters__E2F81969F9C46900").IsUnique();

            entity.Property(e => e.AadharNo).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EpicNo).HasMaxLength(50);
            entity.Property(e => e.FamilyIdno)
                .HasMaxLength(50)
                .HasColumnName("FamilyIDNo");
            entity.Property(e => e.FatherName).HasMaxLength(200);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.RationCardNo).HasMaxLength(50);

            entity.HasOne(d => d.Caste).WithMany(p => p.Voters)
                .HasForeignKey(d => d.CasteId)
                .HasConstraintName("FK__Voters__CasteId__5FB337D6");

            entity.HasOne(d => d.City).WithMany(p => p.Voters)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Voters__CityId__5CD6CB2B");

            entity.HasOne(d => d.District).WithMany(p => p.Voters)
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK__Voters__District__5BE2A6F2");

            entity.HasOne(d => d.Gender).WithMany(p => p.Voters)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Voters__GenderId__60A75C0F");

            entity.HasOne(d => d.Religion).WithMany(p => p.Voters)
                .HasForeignKey(d => d.ReligionId)
                .HasConstraintName("FK__Voters__Religion__5EBF139D");

            entity.HasOne(d => d.State).WithMany(p => p.Voters)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Voters__StateId__5AEE82B9");

            entity.HasOne(d => d.Ward).WithMany(p => p.Voters)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK__Voters__WardId__5DCAEF64");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.WardId).HasName("PK__Wards__C6BD9BCA1C6684E5");

            entity.HasOne(d => d.City).WithMany(p => p.Wards)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Wards__CityId__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
