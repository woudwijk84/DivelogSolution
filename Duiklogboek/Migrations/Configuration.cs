namespace Duiklogboek.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Duiklogboek.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            SeedUsersAndRoles(context);
            //SeedUsers(context);
        }

        private void SeedUsersAndRoles(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!roleManager.RoleExists("admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

            if (!roleManager.RoleExists("diveInstructor"))
            {
                roleManager.Create(new IdentityRole("diveInstructor"));
            }

            if (!(context.Users.Any(u => u.UserName == "rienk")))
            {
                var user = new ApplicationUser { UserName = "rienk", Email = "test@test.nl" };
                userManager.Create(user, "Welkom01");
                userManager.AddToRole(user.Id, "admin");
            }
        }
    }
}
