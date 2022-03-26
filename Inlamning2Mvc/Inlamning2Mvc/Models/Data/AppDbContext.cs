using Inlamning2Mvc.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inlamning2Mvc.Models;

namespace Inlamning2Mvc.Models.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<ProfileEntity> Profiles { get; set; }
        
      
    

      
    }
}
