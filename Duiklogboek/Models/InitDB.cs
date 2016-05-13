using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Duiklogboek.Models
{
    public class InitDB : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (!(context.Users.Any(u=>u.UserName == "rienk")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "rienk", Email = "test@test.nl" };
                userManager.Create(user, "Welkom01");
            }

            base.Seed(context);
        }
    }
}