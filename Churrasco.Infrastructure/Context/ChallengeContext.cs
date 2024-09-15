using Microsoft.EntityFrameworkCore;
using Churrasco.Infrastructure.Entities;

namespace Churrasco.Infrastructure.Context { 

    public partial class ChallengeContext : DbContext
    {
        public ChallengeContext()
        {
        }

        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)    
            => optionsBuilder.UseMySql("server=vps.churrasco.digital;port=3306;database=Challenge;user=challenge;password=challenge", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.23-mariadb"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("products");

                entity.HasIndex(e => e.Sku, "ix_SKU").IsUnique();

                entity.HasIndex(e => e.Code, "ix_code").IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasColumnType("int(11)")
                    .HasColumnName("code");
                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .HasColumnName("currency");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");
                entity.Property(e => e.Picture)
                    .HasMaxLength(1255)
                    .HasColumnName("picture");
                entity.Property(e => e.Price)
                    .HasPrecision(10, 2)
                    .HasColumnName("price");
                entity.Property(e => e.Sku)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("SKU");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");
                entity.Property(e => e.Active)
                    .HasDefaultValueSql("'1'")
                    .HasColumnName("active");
                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");
                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
                entity.Property(e => e.Role)
                    .HasMaxLength(25)
                    .HasColumnName("role");
                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasColumnName("updated");
                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}