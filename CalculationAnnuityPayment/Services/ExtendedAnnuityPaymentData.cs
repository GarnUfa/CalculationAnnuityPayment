using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;

namespace CalculationAnnuityPayment.Services
{
    // TODO Сокрыть лишнее оставить только сервис на выход в VIEW
    internal class ExtendedAnnuityPaymentData : AnnuityPayment, IAnnuityPayment
    {
        public ExtendedAnnuityPaymentData(ExtendedAnnuityPaymentModel model)
        {
            this.creditAmount = model.creditAmount;
            this.percentRate = model.percentRate;
            this.paymentStep = model.paymentStep;
            this.creditPeriod = model.creditPeriod;

            balanceOfDebt = model.creditAmount;
            NumberOfPayments();
            PercentRatePerYear();
            annuityRate = AnnuityRate(percentRatePerYear, numberOfPayments);
            paymentDate = DateTime.Now;

        }

        protected override decimal creditAmount { get; set; }
        protected override decimal percentRate { get; set; }
        protected override int paymentStep { get; set; }
        protected override int creditPeriod { get; set; }
       
        protected override int numberOfPayments { get; set; }
        private void NumberOfPayments() =>
            numberOfPayments = creditPeriod / paymentStep;

        private decimal percentRatePerYear { get; set; }
        private void PercentRatePerYear() =>
            percentRatePerYear = percentRate*creditPeriod;

        protected override DateTime paymentDate { get; set; }
        private void PaymentDate() =>
            paymentDate = paymentDate.AddDays(paymentStep);


        private decimal percentOnDebt { get; set; }
        private decimal mainDebt { get; set; }
        private decimal balanceOfDebt { get; set; }
        private decimal annuityRate { get; set; }

        /// <summary>
        /// Процентная часть в платеже
        /// </summary>
        private void PercentOnDebt() =>
            percentOnDebt = (balanceOfDebt * (percentRatePerYear.PercentNumerical().ByMonth())).Round(4);
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
