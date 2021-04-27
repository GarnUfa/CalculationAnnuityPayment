using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalculationAnnuityPayment.Services
{
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
        }
        /// <summary>
        /// Считаем количество платежей в зависимости от шага платежа
        /// </summary>
        private void NumberOfPayments() =>
            numberOfPayments = creditPeriod / paymentStep;
        /// <summary>
        /// Процентная ставка в год, в шаговом платеже
        /// </summary>
        private decimal percentRatePerYear { get; set; }
        /// <summary>
        /// Считаем процентную ставку в год, в шаговом платеже (проценты в день на кол-во дней)
        /// </summary>
        private void PercentRatePerYear() =>
            percentRatePerYear = percentRate*creditPeriod;


        protected override string PaymentDate(int currentPayment)
        {
            ///Проверяем на кратность периода кредитования шагу платежа
            ///Если не кратен и шаг платежа является последним (последний платеж) то смещаем дату платежа на последний день 
            if (creditPeriod % paymentStep != 0 && currentPayment == numberOfPayments)
            {
                paymentDate = paymentDate.AddDays(paymentStep+(creditPeriod % paymentStep));
            }
            else
            {
                paymentDate = paymentDate.AddDays(paymentStep);
            }
            string _paymentDate = paymentDate.ToString("dddd dd MMMM yyyy",
                  CultureInfo.CreateSpecificCulture("ru-RU"));
            return _paymentDate;
        }

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
