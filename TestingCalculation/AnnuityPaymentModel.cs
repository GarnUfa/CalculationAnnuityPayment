using System;
using System.Collections.Generic;
using System.Text;

namespace TestingCalculation
{
    class AnnuityPaymentModel
    {
        public AnnuityPaymentModel(decimal creditAmount, decimal percentRate, int numberOfMonths)
        {
            this.creditAmount = creditAmount;
            this.percentRate = percentRate;
            this.numberOfMonths = numberOfMonths;
        }

        public decimal creditAmount { get; set; }
        public decimal percentRate { get; set; }
        public int numberOfMonths { get; set; }
    }
}
