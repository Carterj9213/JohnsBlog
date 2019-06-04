namespace JohnsBlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using JohnsBlog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<JohnsBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(JohnsBlog.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //I want to write some code that allows me to introduce a few "roles" into our application
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            //I want to write some code that allows me to introduce a few "roles" into our application
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "Jc56Wrestling@Yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "Jc56Wrestling@Yahoo.com",
                    UserName = "Jc56Wrestling@Yahoo.com",
                    FirstName = "John",
                    LastName = "Carter",
                    DisplayName = "John"
                }, "Blog1234!");
            }

            var userId = userManager.FindByEmail("Jc56wrestling@yahoo.com").Id;
            userManager.AddToRole(userId, "Admin");

            //Moderator

            if (!context.Users.Any(u => u.Email == "Moderator@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "Moderator@Mailinator.com",
                    UserName = "Moderator@Mailinator.com",
                    FirstName = "Tyler",
                    LastName = "Smith",
                    DisplayName = "Tyler"
                }, "Blog1234!");
            }

            userId = userManager.FindByEmail("Moderator@Mailinator.com").Id;
            userManager.AddToRole(userId, "Moderator");



        }
    }
}
