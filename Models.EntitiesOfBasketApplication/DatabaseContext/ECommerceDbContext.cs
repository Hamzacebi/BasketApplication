using Microsoft.EntityFrameworkCore;

namespace Models.EntitiesOfBasketApplication.DatabaseContext
{
    #region Internal Project Usings
    using Entities;
    #endregion Internal Project Usings
    public partial class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasketClosingReasons> BasketClosingReasons { get; set; }
        public virtual DbSet<MemberBaskets> MemberBaskets { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<ProductStocks> ProductStocks { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local); Initial Catalog=ECommerce; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BasketClosingReasons>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MemberBaskets>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.ClosingReason)
                    .WithMany(p => p.MemberBaskets)
                    .HasForeignKey(d => d.ClosingReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberBaskets_BasketClosingReasons");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberBaskets)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberBaskets_Members");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MemberBaskets)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberBaskets_Products");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<ProductStocks>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("Unique_ProductIdOnProductStock")
                    .IsUnique();

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.ProductStocks)
                    .HasForeignKey<ProductStocks>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductStocks_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });
        }
    }
}
