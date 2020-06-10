using Microsoft.EntityFrameworkCore;
using VueAppTsApi.Core.Entities;

namespace VueAppTsApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("app");

            #region Keys
            modelBuilder.Entity<User>().HasKey(nameof(User.Id));
            modelBuilder.Entity<Image>().HasKey(nameof(Image.Id));
            modelBuilder.Entity<UserImage>().HasKey(j => new { j.UserId, j.ImageId });
            #endregion

            #region Relations
            modelBuilder.Entity<UserImage>()
                .HasOne(x => x.User)
                .WithMany(x => x.SavedImages)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserImage>()
                .HasOne(x => x.Image)
                .WithMany(x => x.UserImages)
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Unique Constrains
            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Username })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.Email })
                .IsUnique();
            #endregion
        }
    }
}