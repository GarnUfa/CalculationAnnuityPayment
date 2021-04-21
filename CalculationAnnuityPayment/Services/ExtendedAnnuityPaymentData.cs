using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment.Services
{
    public class ExtendedAnnuityPaymentData : IAnnuityPayment
    {
        public ExtendedAnnuityPaymentData(ExtendedAnnuityPaymentModel model)
        {
            AnnuityPaymentData counter = new AnnuityPaymentData(model);
        }

        public IEnumerable<ViewModel> PaymentList()
        {
            throw new NotImplementedException();
        }
    }
}
