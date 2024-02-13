using ECommerce.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(WebSiteUser user, List<string> roles);
    }
}
