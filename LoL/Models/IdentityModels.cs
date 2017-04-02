using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LoL.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Champion> Champions { get; set; }

        public DbSet<LoLPlayer> Players { get; set; }

        public DbSet<Matchlist> Matchlist{ get; set; }

        public DbSet<StaticRunes> Runes { get; set; }

        public DbSet<StaticMastery> Masteries { get; set; }

        public DbSet<MatchData> Match { get; set; }
        public DbSet<ParticipantList> Participant { get; set; }
        public DbSet<ParticipantId> ParticipantIdentity { get; set; }
        public DbSet<ParticipantMasteries> ParticipantMasteries { get; set; }
        public DbSet<ParticipantRunes> ParticipantRunes { get; set; }
        public DbSet<ParticipantStats> ParticipantStats { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<MatchLanes> MatchLanes { get; set; }



    }
}