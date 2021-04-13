using CalculationAnnuityPayment.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            if (model.creditAmount == 0)
            {
                var i = ModelState["creditAmount"];
                if (ModelState["creditAmount"].Errors.Count>0)
                    ModelState["creditAmount"].Errors.Clear();
                ModelState.AddModelError("creditAmount", "Введите коректное значение");
            }
            if (model.percentRate == 0)
            {
                var i = ModelState["percentRate"];
                if (ModelState["percentRate"].Errors.Count > 0)
                    ModelState["percentRate"].Errors.Clear();
                ModelState.AddModelError("percentRate", "Введите коректное значение");
            }
            if (model.numberOfMonths == 0)
            {
                var i = ModelState["numberOfMonths"];
                if (ModelState["numberOfMonths"].Errors.Count > 0)
                    ModelState["numberOfMonths"].Errors.Clear();
                ModelState.AddModelError("numberOfMonths", "Введите коректное значение");
            }
            if (ModelState.IsValid)
            {
                return Content("<h1>qweq</h1>");
            }
            else
            {
                return View(model);
            }
            
        }
        public IActionResult CalculationResults()
        {
            return View();
        }
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("~/Views/Shared/Error.cshtml", feature?.Error);
        }

    }
}
