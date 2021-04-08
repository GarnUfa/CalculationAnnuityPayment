using System;

namespace TestingCalculation
{
    internal class AnnuityPaymentData
    {
        private decimal creditAmount { get; set; }
        private decimal percentRate { get; set; }
        private decimal numberOfMonths { get; set; }

        public AnnuityPaymentData(AnnuityPaymentModel model)
        {
            creditAmount = model.creditAmount;
            percentRate = model.percentRate;
            numberOfMonths = model.numberOfMonths;
        }

        private decimal AnnuityRate()
        {
            decimal annuityRateValue;
            decimal _percentDoub = percentRate.ByMonth().ToDouble();
            decimal _divider = divider();
            decimal divider()
            {
                return
                    (decimal)(Math.Pow(1 +
                    (double)percentRate.ByMonth().ToDouble(),
                    (double)numberOfMonths) - 1);
            }
            annuityRateValue = creditAmount * (_percentDoub+(_percentDoub / _divider));
            return annuityRateValue.Round(1);
        }
    }

}