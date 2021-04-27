using CalculationAnnuityPayment.Models;
using CalculationAnnuityPayment.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CalculationAnnuityPayment.Controllers
{
    public class AnnuityPaymentController : Controller
    {
        public IActionResult CreditData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreditData(AnnuityPaymentModel model)
        {
            if (ModelState.IsValid)
            {
                IAnnuityPayment am = new AnnuityPaymentData(model);
                IEnumerable<ViewModel> pay = am.PaymentList();
                return View("CalculationResults", pay);
            }
            else
            {
                return View(model);
            }
            
        }
        public IActionResult ExtendedCreditData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ExtendedCreditData(ExtendedAnnuityPaymentModel model)
        {
            if (ModelState.IsValid)
            {
               
                IAnnuityPayment am = new ExtendedAnnuityPaymentData(model);
                IEnumerable<ViewModel> pay = am.PaymentList();
                return View("CalculationResults", pay);
            }
            else
            {
                return View(model);
            }

        }
        public IActionResult CalculationResults(IEnumerable<ViewModel> PaymentTable)
        {
            return View(PaymentTable);
        }
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("~/Views/Shared/Error.cshtml", feature?.Error);
        }

    }
}
