using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POVs.BL.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please Provide User Name")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Provide Password")]
        [MinLength(6, ErrorMessage = "Min len 6")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
