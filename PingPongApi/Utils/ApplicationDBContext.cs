using Microsoft.EntityFrameworkCore;
using PingPongAPI.Entities;

namespace PingPongAPI.Utils
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            //this.Database.EnsureCreated();
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<ShirtSize> ShirtSizes { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(t => t.TeamId)
                .IsRequired();


            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.ShirtSize)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(t => t.ShirtSizeId);

            modelBuilder.Entity<ShirtSize>().HasData(
                new { Id = "XS", Name = "XS" , Order = 0},
                new { Id = "S", Name = "S", Order = 1 },
                new { Id = "M", Name = "M", Order = 2 },
                new { Id = "L", Name = "L", Order = 3 },
                new { Id = "XL", Name = "XL", Order = 4 },
                new { Id = "XXL", Name = "XXL", Order = 5 }
            );

            modelBuilder.Entity<Team>().HasData(
                new { Id = "Red", Name = "Red", Color = "#ff0000" },
                new { Id = "Black", Name = "Black", Color = "#000000" }
            );
        }


    }

}
