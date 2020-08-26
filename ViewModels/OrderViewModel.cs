using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/26/2020 07:10 am - SSN - [20200826-0710] - [001] - M08-05 - Validation and view models

namespace ps_DutchTreat.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Must be at least 4 alphanumeric characters.")]
        public string OrderNumber { get; set; }


        // 08/26/2020 12:29 pm - SSN - [20200826-1226] - [001] - M08-07 -Creating association controller

        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}
