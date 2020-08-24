using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps_DutchTreat.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage= "Must be at least five characters long.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage ="Cannot exceed 250 characters.")]
        public string Message { get; set; }

    }
}
