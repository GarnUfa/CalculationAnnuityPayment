using System;

namespace CalculationAnnuityPayment.Services
{
    internal abstract class AnnuityPayment
    {
        /// <summary>
        /// Сумма кредита
        /// </summary>
        protected abstract decimal creditAmount { get; set; }
        /// <summary>
        /// Процентная ставка
        /// </summary>
        protected abstract decimal percentRate { get; set; }
        /// <summary>
        /// количество платежей
        /// </summary>
        protected abstract int numberOfPayments { get; set; }
        /// <summary>
        /// Срок кредитования
        /// </summary>
        protected abstract int creditPeriod { get; set; }
        /// <summary>
        /// Шаг платежа
        /// </summary>
        protected abstract int paymentStep { get; set; }
        /// <summary>
        /// Дата платежа
        /// </summary>
        protected abstract DateTime paymentDate { get; set; }
        /// <summary>
        /// Аннуитетная ставка(фиксированный платеж на количество платежей)
        /// </summary>
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
    }
}
