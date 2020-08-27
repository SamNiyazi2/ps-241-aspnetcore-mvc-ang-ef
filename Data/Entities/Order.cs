using ps_DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public ICollection<OrderItem> Items { get; set; }

        // 08/26/2020 05:53 pm - SSN - [20200826-1737] - [003] - M09-03 - Storing identities in the database
        public CustomUser user { get; set; }

    }
}
