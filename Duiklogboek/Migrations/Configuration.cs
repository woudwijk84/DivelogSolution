namespace Duiklogboek.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Duiklogboek.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Duiklogboek.Models.ApplicationDbContext";
        }

        protected override void Seed(Duiklogboek.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (!(context.Users.Any(u => u.UserName == "rienk")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "rienk", Email = "test@test.nl" };
                userManager.Create(user, "Welkom01");
            }

            //var passwordHash = new PasswordHasher();
            //string password = passwordHash.HashPassword("Welkom0!");
            //context.Users.AddOrUpdate(a => a.UserName, new ApplicationUser
            //{
            //    UserName = "rienk",
            //    PasswordHash = password,
            //    Email = "test@test.nl"
            //});
        }
    }
}
