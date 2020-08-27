using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/27/2020 02:19 am - SSN - [20200827-0153] - [004] - M09-05 - Designing the login view

namespace ps_DutchTreat.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
