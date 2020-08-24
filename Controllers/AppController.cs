using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/23/2020 08:39 pm - SSN - [20200823-2037] - [001] - M05-03 - First controller/view 

namespace ps_DutchTreat.Controllers
{
    public class AppController: Controller
    {
        
        public IActionResult Index()
        { 
            return View();
        }
    }
}
