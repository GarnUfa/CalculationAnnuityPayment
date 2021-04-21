using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment.Models
{
    public class ExtendedAnnuityPaymentModel : AnnuityPaymentModel
    {
        public override decimal creditAmount { get => base.creditAmount; set => base.creditAmount = value; }
        public override decimal percentRate { get => base.percentRate; set => base.percentRate = value; }
        public override int LoanTerm { get => base.LoanTerm; set => base.LoanTerm = value; }
        public int paymentStep { get; set; }
    }
}
