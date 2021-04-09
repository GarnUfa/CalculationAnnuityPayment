using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment.Controllers
{
    public class AnnuityPayment : Controller
    {
        public IActionResult CreditData()
        {
            return View();
        }
        public IActionResult CalculationResults()
        {
            return View();
        }
        
    }
}
