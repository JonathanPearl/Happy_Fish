using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HappyFish.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

        public System.Data.Entity.DbSet<HappyFish.TankEnvironment> TankEnvironments { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Fishery> Fisheries { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Tank> Tanks { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Event> Events { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Product> Products { get; set; }

        public System.Data.Entity.DbSet<HappyFish.LifeStage> LifeStages { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Nutrition> Nutritions { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Need> Needs { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Business> Businesses { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<HappyFish.Supplier> Suppliers { get; set; }
    }
}