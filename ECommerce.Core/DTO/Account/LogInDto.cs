using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.Account
{
    public class LogInDto
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
