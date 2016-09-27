using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarFinder.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
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

        public DbSet<Car> Cars { get; set; }

        public async Task<List<string>> GetAllYears()
        {
            return await Database.SqlQuery<string>("GetAllYears").ToListAsync();
        }

        public async Task<List<string>> GetAllMakes(string year)
        {
            return await Database.SqlQuery<string>("GetAllMakes @year",
                new SqlParameter("year", year)).ToListAsync();
        }

        public async Task<List<string>> GetAllModels(string year, string make)
        {
            return await Database.SqlQuery<string>("GetAllModels @year, @make",
                new SqlParameter("year", year), 
                new SqlParameter("make", make)).ToListAsync();
        }

        public async Task<List<string>> GetAllTrims(string year, string make, string modelName)
        {
            return await Database.SqlQuery<string>("GetAllTrims @year, @make, @modelName",
               new SqlParameter("year", year),
               new SqlParameter("make", make),
               new SqlParameter("modelName", modelName)).ToListAsync();
        }

        public async Task<List<string>> GetCar(string year, string make, string modelName, string modelTrim)
        {
            return await Database.SqlQuery<string>("GetCar @year, @make, @modelName, @modelTrim",
               new SqlParameter("year", year),
               new SqlParameter("make", make),
               new SqlParameter("modelName", modelName),
               new SqlParameter("modelTrim", modelTrim)).ToListAsync();
        }
    }
}