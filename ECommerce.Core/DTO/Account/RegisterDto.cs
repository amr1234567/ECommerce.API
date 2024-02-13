using ECommerce.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.DTO.Account
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="{0} is required")]
        [Display(Name="User Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="{0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare(nameof(Password),ErrorMessage = "Doesn't match with Password")]
        [Required(ErrorMessage ="{0} is required")]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }


        public WebSiteUser ConvertToUser()
        {
            return new WebSiteUser
            {
                Email = Email,
                UserName = Email,
            };
        }
    }
}
