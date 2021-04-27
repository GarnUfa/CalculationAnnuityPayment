using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalculationAnnuityPayment.Services
{
    internal class AnnuityPaymentData: AnnuityPayment, IAnnuityPayment
    {
        public AnnuityPaymentData(AnnuityPaymentModel model)
        {
            paymentStep = 30;
            creditAmount = model.creditAmount;
            percentRate = model.percentRate;
            creditPeriod = model.creditPeriod;
            numberOfPayments = model.creditPeriod;

            balanceOfDebt = model.creditAmount;
            annuityRate = AnnuityRate(percentRate, numberOfPayments);
        }

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

        
        private ViewModel ViewData(int currentPayment)
        {
            PercentOnDebt();
            MainDebt();
            BalanceOfDebt();
            return new ViewModel(
                currentPayment,
                PaymentDate(currentPayment),
                balanceOfDebt,
                percentOnDebt,
                mainDebt,
                annuityRate
                );
        }
        public IEnumerable<ViewModel> PaymentList()
        {
            for (int i = 1; i <= numberOfPayments; i++)
            {
                yield return ViewData(i);
            }
        }

    }

}