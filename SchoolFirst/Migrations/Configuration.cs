namespace SchoolFirst.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SchoolFirst.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolFirst.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolFirst.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
           new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "daisy.blue@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "daisy.blue@gmail.com",
                    Email = "daisy.blue@gmail.com",
                    FirstName = "Daisy",
                    LastName = "Blue",
                    DisplayName = "DB"
                }, "Bposts19!");
            }

            var userId = userManager.FindByEmail("daisy.blue@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            //Create Instructor role
            var roleManager1 = new RoleManager<IdentityRole>(
           new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Instructor"))
            {
                roleManager.Create(new IdentityRole { Name = "Instructor" });
            }

            //Create StudentRole
            var roleManager2 = new RoleManager<IdentityRole>(
           new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Student"))
            {
                roleManager.Create(new IdentityRole { Name = "Student" });
            }

            //context.Instructors.AddOrUpdate(//
            //      p => p.Id,
            //      new Instructor {  FirstName = "Sam", LastName = "Riley"},
            //      new Instructor {  FirstName = "Sue", LastName = "Jason" }
            //    );
            //context.Students.AddOrUpdate(
            //      p => p.Id,   new Student {  FirstName = "Jill", LastName = "Rain", EnrollmentDate = DateTimeOffset.Parse("10/18/2018")},
            //      new Student {  FirstName = "Rose", LastName = "Saber", EnrollmentDate = DateTimeOffset.Parse("11/19/2018") }
            //    );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
