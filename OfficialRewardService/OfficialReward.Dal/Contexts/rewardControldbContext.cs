using System;
using Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OfficialReward.Dal.Contexts
{
    public partial class rewardControldbContext : DbContext
    {

        public rewardControldbContext(DbContextOptions<rewardControldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuisenessBook> BuisenessBooks { get; set; }
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LastWork> LastWorks { get; set; }
        public virtual DbSet<PrivateBusiness> PrivateBusinesses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkPost> WorkPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuisenessBook>(entity =>
            {
                entity.HasKey(e => e.BuisenessBookId);

                entity.Property(e => e.CreatingDate);
            });

            modelBuilder.Entity<Command>(entity =>
            {
                entity.HasKey(e => e.CommandId);

                entity.Property(e => e.CommandId).ValueGeneratedNever();

                entity.Property(e => e.CommandDate);

                entity.Property(e => e.CommandText)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(e => e.EducationId);

                entity.Property(e => e.EducationPlace).HasMaxLength(50);

                entity.Property(e => e.EducationType).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeMiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PrivateBusiness)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PrivateBusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Subdivision)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SubdivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WorkPost)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.WorkPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LastWork>(entity =>
            {
                entity.HasKey(e => e.LastWorkId);

                entity.Property(e => e.WorkPlace).HasMaxLength(50);

                entity.Property(e => e.WorkPost).HasMaxLength(50);

                entity.Property(e => e.WorkTime).HasMaxLength(50);
            });

            modelBuilder.Entity<PrivateBusiness>(entity =>
            {
                entity.HasKey(e => e.PrivateBusinessId);

                entity.Property(e => e.Autobiography).HasMaxLength(255);

                entity.HasOne(d => d.BuisenessBook)
                    .WithMany(p => p.PrivateBusinesses)
                    .HasForeignKey(d => d.BuisenessBookId);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.HasKey(e => e.RewardId);

                entity.Property(e => e.RewardName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subdivision>(entity =>
            {
                entity.HasKey(e => e.SubdivisionId);

                entity.Property(e => e.SubdivisionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserMiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.WorkPost)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.WorkPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkPost>(entity =>
            {
                entity.HasKey(e => e.WorkPostId);

                entity.Property(e => e.WorkPostName).HasMaxLength(50);
            });
        }
    }
}
