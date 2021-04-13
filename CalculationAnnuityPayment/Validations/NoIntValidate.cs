using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment.Validations
{
    public class NoIntValidate : ValidationAttribute
    {
        public NoIntValidate()
        {
            ErrorMessage = "Введите число";
        }


        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }
            return false;
        }
    }
}
