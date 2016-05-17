using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

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
            modelBuilder.Entity<FundSources>(entity =>
            {
                entity.HasKey(e => e.FundSourceID);

                entity.Property(e => e.FundSourceDeleted).HasDefaultValue(false);

                entity.Property(e => e.FundSourceDTS).HasColumnType("datetime");

                entity.Property(e => e.FundSourceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FundSourceUserID)
                    .IsRequired()
                    .HasMaxLength(450);
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
            });
        }

        public virtual DbSet<FundSources> FundSources { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TransactionTags> TransactionTags { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
    }
}