using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForEndUser
{
    public class LogInReturn
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
