﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.ForEndUser
{
    public class LogInReturn
    {
        public string Token { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public DateTime TokenExpiration { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
