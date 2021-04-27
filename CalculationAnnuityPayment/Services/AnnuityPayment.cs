using System;
using System.Globalization;

namespace CalculationAnnuityPayment.Services
{
    internal abstract class AnnuityPayment
    {
        /// <summary>
        /// Сумма кредита
        /// </summary>
        protected decimal creditAmount { get; set; }
        /// <summary>
        /// Процентная ставка
        /// </summary>
        protected decimal percentRate { get; set; }
        /// <summary>
        /// количество платежей
        /// </summary>
        protected int numberOfPayments { get; set; }
        /// <summary>
        /// Срок кредитования
        /// </summary>
        protected int creditPeriod { get; set; }
        /// <summary>
        /// Шаг платежа
        /// </summary>
        protected int paymentStep { get; set; }
        /// <summary>
        /// Дата платежа
        /// </summary>
        protected DateTime paymentDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Процентная часть в платеже
        /// </summary>
        protected decimal percentOnDebt { get; set; }
        /// <summary>
        /// Основной платеж
        /// </summary>
        protected decimal mainDebt { get; set; }
        /// <summary>
        /// Сумма долга на момент платежа
        /// </summary>
        protected decimal balanceOfDebt { get; set; }

        protected decimal annuityRate { get; set; }

        /// <summary>
        /// Аннуитетная ставка(фиксированный платеж на количество платежей)
        /// </summary>
        /// 
        protected decimal AnnuityRate(decimal percentRate, int numberOfPayments)
        {
            decimal annuityRateValue;
            decimal _percentDoub = percentRate.ByMonth().PercentNumerical();
            decimal _divider = divider();
            decimal divider()
            {
                return
                    (decimal)(Math.Pow(1 +
                    (double)_percentDoub,
                    (double)numberOfPayments));
            }
            annuityRateValue = creditAmount * (_percentDoub * _divider / (_divider - 1));
            return annuityRateValue.Round(4);
        }
        /// <summary>
        /// Считаем дату платежа \ формируем вид даты платежа
        /// </summary>
        protected virtual string PaymentDate(int numberOfPayments)
        {
            paymentDate = paymentDate.AddDays(paymentStep);
            string _paymentDate = paymentDate.ToString("dddd dd MMMM yyyy",
                  CultureInfo.CreateSpecificCulture("ru-RU"));
            return _paymentDate;
        }

    }
}
