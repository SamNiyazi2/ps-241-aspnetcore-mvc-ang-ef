
// 08/26/2020 12:30 pm - SSN - [20200826-1226] - [002] - M08-07 -Creating association controller

using System.ComponentModel.DataAnnotations;

namespace ps_DutchTreat.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string ProductCategory { get; set; }
        public string ProductSize { get; set; }
        public string ProductTitle { get; set; }
        public string ProductArtist { get; set; }
        public string ProductArtId { get; set; }

    }
}