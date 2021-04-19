using System;
using System.Collections.Generic;
using System.Text;

namespace TestingCalculation
{
    class ViewModel
    {
        /// <summary>
        /// Остаток долга 
        /// Остаток долга за прошл мес - 
        /// </summary>
        public decimal balanceOfDebt { get; set; }
        /// <summary>
        /// Часть платежа относящаяся к % (сколько процентов мы заплатили)
        /// </summary>
        public decimal percentOnDebt { get; set; }
        /// <summary>
        /// "Остаток основного долга
        /// Еж платеж - процентная часть долга
        /// </summary>
        public decimal mainDebt { get; set; }
        /// <summary>
        /// Сумма платежа (общая неизменная)
        /// </summary>
        public decimal amountOfPayment { get; set; }
    }
}
