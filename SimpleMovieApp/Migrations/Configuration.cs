namespace SimpleMovieApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;
    internal sealed class Configuration : DbMigrationsConfiguration<SimpleMovieApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            // Ensure Stephen
            var user = userManager.FindByName("Stephen.Walther@superexpert.com");
            if (user == null)
            {
                // create user
                user = new ApplicationUser
                {
                    UserName = "Stephen.Walther@superexpert.com",
                    Email = "Stephen.Walther@superexpert.com"
                };
                userManager.Create(user, "Secret123!");

                // add claims
                userManager.AddClaim(user.Id, new Claim("CanViewMovies", "true"));
                userManager.AddClaim(user.Id, new Claim(ClaimTypes.DateOfBirth, "12/25/1966"));
            }
        }

    }
}
