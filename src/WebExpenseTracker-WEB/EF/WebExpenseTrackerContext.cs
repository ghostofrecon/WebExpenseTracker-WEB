using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using WebExpenseTracker_WEB.Models.API.TransactionTag;

namespace WebExpenseTracker_WEB.EF
{
    public partial class WebExpenseTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.\SQL2012;Initial Catalog=WebExpenseTracker;Integrated Security=False;User ID=webtrackerlogin;Password=webtrackerpassword;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName).HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role).WithMany(p => p.AspNetUserRoles).HasForeignKey(d => d.RoleId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User).WithMany(p => p.AspNetUserRoles).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail).HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName).HasName("UserNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<FundSources>(entity =>
            {
                entity.HasKey(e => e.FundSourceID);

                entity.Property(e => e.FundSourceDTS).HasColumnType("datetime");

                entity.Property(e => e.FundSourceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FundSourceUserID)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.FundSourceUser).WithMany(p => p.FundSources).HasForeignKey(d => d.FundSourceUserID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagID);

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TagUserID)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.TagUser).WithMany(p => p.Tags).HasForeignKey(d => d.TagUserID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TransactionTags>(entity =>
            {
                entity.HasKey(e => e.TransactionTagID);

                entity.Property(e => e.TransactionTagID).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionTags).HasForeignKey(d => d.TransactionID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.TransactionTag).WithOne(p => p.TransactionTags).HasForeignKey<TransactionTags>(d => d.TransactionTagID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionID);

                entity.Property(e => e.TransactionDeleted).HasDefaultValue(false);

                entity.Property(e => e.TransactionDTS).HasColumnType("datetime");

                entity.Property(e => e.TransactionIsCredit).HasDefaultValue(false);

                entity.Property(e => e.TransactionUserID)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.TransactionFundSource).WithMany(p => p.Transactions).HasForeignKey(d => d.TransactionFundSourceID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.TransactionUser).WithMany(p => p.Transactions).HasForeignKey(d => d.TransactionUserID).OnDelete(DeleteBehavior.Restrict);
            });
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<FundSources> FundSources { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TransactionTags> TransactionTags { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionTag> TransactionTag { get; set; }
    }
}