using E_Commerce.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.persistence.Authcontext
{
    public class AuthDbContext(DbContextOptions<AuthDbContext> dbContext) : 
        IdentityDbContext<ApplicationUser>(dbContext)
    {
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
