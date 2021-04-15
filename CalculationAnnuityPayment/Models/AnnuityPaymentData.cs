using CalculationAnnuityPayment.Models;
using System;

namespace TestingCalculation
{
    internal class AnnuityPaymentData
    {
        private decimal? creditAmount { get; set; }
        private decimal? percentRate { get; set; }
        private decimal? numberOfMonths { get; set; }

        public AnnuityPaymentData(AnnuityPaymentModel model)
        {
            creditAmount = model.creditAmount;
            percentRate = model.percentRate;
            numberOfMonths = model.numberOfMonths;

            balanceOfDebt = model.creditAmount;
            annuityRate = AnnuityRate();
        }

        private decimal? AnnuityRate()
        {
            decimal? annuityRateValue;
            decimal? _percentDoub = percentRate.ByMonth().PercentNumerical();
            decimal _divider = divider();
            decimal divider()
            {
                return
                    (decimal)(Math.Pow(1 +
                    (double)percentRate.ByMonth().PercentNumerical(),
                    (double)numberOfMonths) - 1);
            }
            annuityRateValue = creditAmount * (_percentDoub + (_percentDoub / _divider));
            return annuityRateValue.Round(4);
        }

        private decimal? balanceOfDebt { get; set; }
        private decimal? percentOnDebt { get; set; }
        private decimal? mainDebt { get; set; }
        private decimal? annuityRate { get; set; }

        private void PercentOnDebt() =>
            percentOnDebt = (balanceOfDebt * (percentRate.PercentNumerical().ByMonth())).Round(4);
        private void MainDebt() =>
            mainDebt = annuityRate - percentOnDebt;
        private void BalanceOfDebt() =>
            balanceOfDebt = balanceOfDebt - mainDebt;


        public ViewModel ViewData()
        {
            PercentOnDebt();
            MainDebt();
            BalanceOfDebt();
            return new ViewModel(
                balanceOfDebt,
                percentOnDebt,
                mainDebt,
                annuityRate
                );
        }

    }

}