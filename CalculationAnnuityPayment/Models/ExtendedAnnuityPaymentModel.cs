﻿using System;
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
        public override int numberOfPayments { get => base.numberOfPayments; set => base.numberOfPayments = value; }
        public int paymentStep { get; set; }
    }
}