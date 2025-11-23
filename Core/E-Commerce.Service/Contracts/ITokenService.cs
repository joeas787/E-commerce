using E_Commerce.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Contracts
{
    public interface ITokenService
    {
        string GetToken(ApplicationUser user,IList<string> roles);
    }
}
