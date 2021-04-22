using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;

namespace CalculationAnnuityPayment.Services
{
    internal class AnnuityPaymentData: IAnnuityPayment
    {
        private decimal creditAmount { get; set; }
        private decimal percentRate { get; set; }
        private int numberOfPayments { get; set; }
        private int paymentStep { get; set; }

        public AnnuityPaymentData(AnnuityPaymentModel model)
        {
            creditAmount = model.creditAmount;
            percentRate = model.percentRate;
            numberOfPayments = model.numberOfPayments;

            balanceOfDebt = model.creditAmount;
            annuityRate = AnnuityRate();
            paymentDate = DateTime.Now;
            if(model.GetType() == typeof(ExtendedAnnuityPaymentModel))
            {
                ExtendedAnnuityPaymentModel mod = (ExtendedAnnuityPaymentModel)model;
                paymentStep = mod.paymentStep;
            }
        }

        //private int ReductionToByDayCalculation(int numberOfPayments, int paymentStep)
        //{
        //    int i = numberOfPayments % paymentStep;
        //    if (i == 0)
        //    {
        //        return (numberOfPayments / paymentStep);
        //    }
        //    else
        //    {

        //    }
        //}
        private decimal AnnuityRate()
        {
            decimal annuityRateValue;
            decimal _percentDoub = percentRate.ByMonth().PercentNumerical();
            decimal _divider = divider();
            decimal divider()
            {
                return
                    (decimal)(Math.Pow(1 +
                    (double)percentRate.ByMonth().PercentNumerical(),
                    (double)numberOfPayments) - 1);
            }
            annuityRateValue = creditAmount * (_percentDoub + (_percentDoub / _divider));
            return annuityRateValue.Round(4);
        }

        private decimal balanceOfDebt { get; set; }
        private decimal percentOnDebt { get; set; }
        private decimal mainDebt { get; set; }
        private decimal annuityRate { get; set; }
        public DateTime paymentDate { get; set; }

        private void PercentOnDebt() =>
            percentOnDebt = (balanceOfDebt * (percentRate.PercentNumerical().ByMonth())).Round(4);
        private void MainDebt() =>
            mainDebt = annuityRate - percentOnDebt;
        private void BalanceOfDebt() =>
            balanceOfDebt = balanceOfDebt - mainDebt;
        private void PaymentDate() =>
            paymentDate = paymentDate.AddDays(30);


        private ViewModel ViewData(int numberOfMonths)
        {
            PaymentDate();
            PercentOnDebt();
            MainDebt();
            BalanceOfDebt();
            return new ViewModel(
                numberOfMonths,
                paymentDate,
                balanceOfDebt,
                percentOnDebt,
                mainDebt,
                annuityRate
                );
        }
        public IEnumerable<ViewModel> PaymentList()
        {
            for (int i = 0; i < numberOfPayments; i++)
            {
                yield return ViewData(i);
            }
        }

    }

}