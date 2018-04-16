using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Constituencies> Constituencies { get; set; }
        public virtual DbSet<ConstituencyVillages> ConstituencyVillages { get; set; }
        public virtual DbSet<PoliticalLeaders> PoliticalLeaders { get; set; }
        public virtual DbSet<PoliticalParty> PoliticalParty { get; set; }
        public virtual DbSet<Volunteers> Volunteers { get; set; }
        public virtual DbSet<VotersInfo> VotersInfo { get; set; }
        public virtual DbSet<VotingKendras> VotingKendras { get; set; }
        public virtual DbSet<Votings> Votings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=WINJITLAPTOP19;Database=Election;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Constituencies>(entity =>
            {
                entity.HasKey(e => e.ConstituencyId);

                entity.Property(e => e.ConstituencyDistrict).HasMaxLength(500);

                entity.Property(e => e.ConstituencyElectionCommition).HasMaxLength(500);

                entity.Property(e => e.ConstituencyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FutureUse).HasMaxLength(500);
            });

            modelBuilder.Entity<ConstituencyVillages>(entity =>
            {
                entity.HasKey(e => e.VillageId);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.VillageDistrict).HasMaxLength(500);

                entity.Property(e => e.VillageName).HasMaxLength(500);

                entity.Property(e => e.VillageTaluka).HasMaxLength(500);

                entity.HasOne(d => d.Constituencies)
                    .WithMany(p => p.ConstituencyVillages)
                    .HasForeignKey(d => d.ConstituenciesId)
                    .HasConstraintName("FK_ConstituencyVillages_Constituencies");
            });

            modelBuilder.Entity<PoliticalLeaders>(entity =>
            {
                entity.HasKey(e => e.PoliticalLeaderId);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PoliticalLeaderAddress).HasMaxLength(500);

                entity.Property(e => e.PoliticalLeaderMobileNumber).HasMaxLength(50);

                entity.Property(e => e.PoliticalLeaderName).HasMaxLength(500);

                entity.Property(e => e.PoliticalPartyPassword).HasMaxLength(50);

                entity.HasOne(d => d.Constituencies)
                    .WithMany(p => p.PoliticalLeaders)
                    .HasForeignKey(d => d.ConstituenciesId)
                    .HasConstraintName("FK_PoliticalParties_Constituencies");

                entity.HasOne(d => d.PoliticalParty)
                    .WithMany(p => p.PoliticalLeaders)
                    .HasForeignKey(d => d.PoliticalPartyId)
                    .HasConstraintName("FK_PoliticalParties_PoliticalParties");
            });

            modelBuilder.Entity<PoliticalParty>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PoliticalPartyName).HasMaxLength(500);
            });

            modelBuilder.Entity<Volunteers>(entity =>
            {
                entity.HasKey(e => e.VolunteerId);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.VolunteerAddress).HasMaxLength(500);

                entity.Property(e => e.VolunteerMobileNumber).HasMaxLength(500);

                entity.Property(e => e.VolunteerName).HasMaxLength(500);

                entity.HasOne(d => d.PoliticalLeaders)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.PoliticalLeadersId)
                    .HasConstraintName("FK_Volunteers_PoliticalLeaders");

                entity.HasOne(d => d.Village)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.VillageId)
                    .HasConstraintName("FK_Volunteers_ConstituencyVillages");
            });

            modelBuilder.Entity<VotersInfo>(entity =>
            {
                entity.HasKey(e => e.VoterId);

                entity.Property(e => e.VoterId).ValueGeneratedNever();

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber).HasMaxLength(60);

                entity.Property(e => e.IsAlive).HasColumnName("isAlive");

                entity.Property(e => e.IsMigrant).HasColumnName("isMigrant");

                entity.Property(e => e.VillageId).ValueGeneratedOnAdd();

                entity.Property(e => e.VoterFatherName).HasMaxLength(500);

                entity.Property(e => e.VoterName).HasMaxLength(500);

                entity.HasOne(d => d.Village)
                    .WithMany(p => p.VotersInfo)
                    .HasForeignKey(d => d.VillageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VotersInfo_ConstituencyVillages");
            });

            modelBuilder.Entity<VotingKendras>(entity =>
            {
                entity.HasKey(e => e.VotingKendraId);

                entity.Property(e => e.VotingKendraId).ValueGeneratedNever();

                entity.Property(e => e.ConstituencyVillagesId).HasColumnName("ConstituencyVillagesID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.VotingKendraName).HasMaxLength(500);

                entity.HasOne(d => d.ConstituencyVillages)
                    .WithMany(p => p.VotingKendras)
                    .HasForeignKey(d => d.ConstituencyVillagesId)
                    .HasConstraintName("FK_VotingKendras_ConstituencyVillages");
            });

            modelBuilder.Entity<Votings>(entity =>
            {
                entity.HasKey(e => e.VotingId);

                entity.Property(e => e.CreatedBy).HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceBy).HasMaxLength(500);

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.Votings)
                    .HasForeignKey(d => d.PartyId)
                    .HasConstraintName("FK_Votings_PoliticalParty");

                entity.HasOne(d => d.Volunteers)
                    .WithMany(p => p.Votings)
                    .HasForeignKey(d => d.VolunteersId)
                    .HasConstraintName("FK_Votings_Volunteers");

                entity.HasOne(d => d.VotingKendra)
                    .WithMany(p => p.Votings)
                    .HasForeignKey(d => d.VotingKendraId)
                    .HasConstraintName("FK_Votings_VotingKendras");
            });
        }
    }
}
