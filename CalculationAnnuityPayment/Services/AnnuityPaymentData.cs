using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;

namespace CalculationAnnuityPayment.Services
{
    internal class AnnuityPaymentData: AnnuityPayment, IAnnuityPayment
    {
        protected override decimal creditAmount { get; set; }
        protected override decimal percentRate { get; set; }
        protected override int numberOfPayments { get; set; }
        protected override int creditPeriod { get; set; }
        protected override int paymentStep { get; set; } = 30;
        protected override DateTime paymentDate { get; set; }

        public AnnuityPaymentData(AnnuityPaymentModel model)
        {
            creditAmount = model.creditAmount;
            percentRate = model.percentRate;
            creditPeriod = model.creditPeriod;
            numberOfPayments = model.creditPeriod;

            balanceOfDebt = model.creditAmount;
            annuityRate = AnnuityRate(percentRate, creditPeriod);
            paymentDate = DateTime.Now;
        }

        private decimal percentOnDebt { get; set; }
        private decimal mainDebt { get; set; }
        private decimal balanceOfDebt { get; set; }
        private decimal annuityRate { get; set; }
        
        /// <summary>
        /// Процентная часть в платеже
        /// </summary>
        private void PercentOnDebt() =>
            percentOnDebt = (balanceOfDebt * (percentRate.PercentNumerical().ByMonth())).Round(4);
        /// <summary>
        /// Основной платеж
        /// </summary>
        private void MainDebt() =>
            mainDebt = annuityRate - percentOnDebt;
        /// <summary>
        /// Сумма долга на момент платежа
        /// </summary>
        private void BalanceOfDebt() =>
            balanceOfDebt = balanceOfDebt - mainDebt;
        /// <summary>
        /// Дата платежа
        /// </summary>
        private void PaymentDate() =>
            paymentDate = paymentDate.AddDays(paymentStep);


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
            for (int i = 0; i < creditPeriod; i++)
            {
                yield return ViewData(i);
            }
        }

    }

}