﻿using CalculationAnnuityPayment.Validations;
using System.ComponentModel.DataAnnotations;

namespace CalculationAnnuityPayment.Models
{
    public class AnnuityPaymentModel
    {
        [Required(ErrorMessage = "Введите сумму кредитования")]
        [Range(10000, 10000000, ErrorMessage = "Введите сумму от 10000 до 10000000")]
        public decimal? creditAmount { get; set; }
        [Required(ErrorMessage = "Введите процентную ставку")]
        [Range(1, 100, ErrorMessage = "Неверная процентная ставка")]
        public decimal percentRate { get; set; }
        [Required(ErrorMessage = "Введите срок кредитования в месяцах")]
        [Range(6, 600, ErrorMessage = "Неверный срок кредитования")]
        public decimal numberOfMonths { get; set; }

    }
}
