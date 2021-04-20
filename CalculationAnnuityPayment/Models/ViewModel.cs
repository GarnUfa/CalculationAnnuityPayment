using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CalculationAnnuityPayment.Models
{
    public class ViewModel
    {
        public ViewModel(int paymentNumber, DateTime paymentDate, decimal balanceOfDebt, decimal percentOnDebt, decimal mainDebt, decimal amountOfPayment)
        {
            this.paymentNumber = paymentNumber;
            this.paymentDate = paymentDate;
            this.balanceOfDebt = balanceOfDebt;
            this.percentOnDebt = percentOnDebt;
            this.mainDebt = mainDebt;
            this.amountOfPayment = amountOfPayment;
        }

        /// <summary>
        /// Номер платежа. Он же количество месяцей\дней зависит от типа подсчета (по дням или месяцам)
        /// </summary>
        /// 
        [Display(Name = "Нлмер платежа")]
        public int paymentNumber { get; set; }
        /// <summary>
        /// Дата платежа
        /// </summary>
        /// 
        [Display(Name = "Дата платежа")]
        public DateTime paymentDate { get; set; }
        /// <summary>
        /// Остаток долга 
        /// Остаток долга за прошл мес
        /// </summary>
        /// 
        [Display(Name = "Остаток долга")]
        public decimal balanceOfDebt { get; set; }
        /// <summary>
        /// Часть платежа относящаяся к % (сколько процентов мы заплатили)
        /// </summary>
        /// 
        [Display(Name = "Проценты по долгу")]
        public decimal percentOnDebt { get; set; }
        /// <summary>
        /// "Остаток основного долга
        /// Еж платеж - процентная часть долга
        /// </summary>
        /// 
        [Display(Name = "Основной долг")]
        public decimal mainDebt { get; set; }
        /// <summary>
        /// Сумма платежа (общая неизменная)
        /// </summary>
        [Display(Name = "Сумма платежа")]
        public decimal amountOfPayment { get; set; }

    }
}
