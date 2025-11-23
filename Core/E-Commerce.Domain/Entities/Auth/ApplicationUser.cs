using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string? FName { get; set; }

        public string? LName { get; set; }

        public string? DisplayName { get; set; }

        public Address Address { get; set; }

    }
}
