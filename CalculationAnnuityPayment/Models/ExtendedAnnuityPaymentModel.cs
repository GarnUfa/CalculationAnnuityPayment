using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment.Models
{
    public class ExtendedAnnuityPaymentModel : AnnuityPaymentModel
    {
        public override decimal creditAmount { get => base.creditAmount; set => base.creditAmount = value; }
        public override decimal percentRate { get => base.percentRate; set => base.percentRate = value; }
        [Display(Name = "Срок кредитования")]
        [Required(ErrorMessage = "Введите срок кредитования (дни)")]
        [Range(1, 3650, ErrorMessage = "Неверный срок кредитования")]
        public override int creditPeriod { get => base.creditPeriod; set => base.creditPeriod = value; }
        [Display(Name = "Шаг платежа")]
        [Required(ErrorMessage = "Введите срок шаг платежа (дни)")]
        [Range(2, 50, ErrorMessage = "Неверный шаг платежа")]
        public int paymentStep { get; set; }
    }
}
