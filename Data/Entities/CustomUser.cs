using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps_DutchTreat.Data.Entities
{
    // 08/26/2020 05:44 pm - SSN - [20200826-1737] - [001] - M09-03 - Storing identities in the database

    public class CustomUser : IdentityUser // "StoreUser" in video
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
