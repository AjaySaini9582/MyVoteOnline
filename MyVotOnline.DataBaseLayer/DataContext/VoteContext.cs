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

    public virtual DbSet<ChangeRequest> ChangeRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voter> Voters { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-P974GNKB;Database=VoteDb;User Id=Ajay;Password=1234;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.CandidateId).HasName("PK__Candidat__DF539B9CFDC71868");

            entity.Property(e => e.ElectionSymbol).HasMaxLength(100);
            entity.Property(e => e.PartyName).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Candidate__UserI__5AEE82B9");

            entity.HasOne(d => d.Ward).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK__Candidate__WardI__5BE2A6F2");
        });

        modelBuilder.Entity<ChangeRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__ChangeRe__33A8517A71BA9918");

            entity.Property(e => e.FieldName).HasMaxLength(100);
            entity.Property(e => e.NewValue).HasMaxLength(255);
            entity.Property(e => e.OldValue).HasMaxLength(255);
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Candidate).WithMany(p => p.ChangeRequests)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("FK__ChangeReq__Candi__66603565");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A6D1D0A08");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61604044EB0D").IsUnique();

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C4F03D03C");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534FA861680").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__571DF1D5");

            entity.HasOne(d => d.Ward).WithMany(p => p.Users)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Users__WardId__5812160E");
        });

        modelBuilder.Entity<Voter>(entity =>
        {
            entity.HasKey(e => e.VoterId).HasName("PK__Voters__12D25BF8204A440D");

            entity.HasIndex(e => e.VoterCardNumber, "UQ__Voters__842F8418DE05B780").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.VoterCardNumber).HasMaxLength(50);

            entity.HasOne(d => d.Ward).WithMany(p => p.Voters)
                .HasForeignKey(d => d.WardId)
                .HasConstraintName("FK__Voters__WardId__60A75C0F");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.WardId).HasName("PK__Wards__C6BD9BCAF17E7F97");

            entity.HasIndex(e => e.WardName, "UQ__Wards__331BD2294A9D441D").IsUnique();

            entity.Property(e => e.WardName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
