using Entrega2.PGPIC.Shared.Entities;
using Entrega2.PGPIC.Shared.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entrega2.PGPIC.API.Data
{
    public class PGPICContext : IdentityDbContext<User>
    {
        public PGPICContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ResearchProject> ResearchProjects { get; set; }
        public DbSet<Researcher> Researchers { get; set; }
        public DbSet<ResearchActivity> ResearchActivities { get; set; }
        public DbSet<SpecializedResource> SpecializedResources { get; set; }
        public DbSet<Publication> Publications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
