using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationAnnuityPayment.Models
{
    public class AnnuityPaymentModel
    {
        //public AnnuityPaymentModel(decimal creditAmount, decimal percentRate, decimal numberOfMonths)
        //{
        //    this.creditAmount = creditAmount;
        //    this.percentRate = percentRate;
        //    this.numberOfMonths = numberOfMonths;
        //}

        public decimal creditAmount { get; set; }
        public decimal percentRate { get; set; }
        public decimal numberOfMonths { get; set; }
    }
}
