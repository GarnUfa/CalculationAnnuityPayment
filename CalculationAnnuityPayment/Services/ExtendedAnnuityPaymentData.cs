using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment.Services
{
    // TODO Сокрыть лишнее оставить только сервис на выход в VIEW
    public class ExtendedAnnuityPaymentData : IAnnuityPayment
    {
        public ExtendedAnnuityPaymentData(ExtendedAnnuityPaymentModel model)
        {
            AnnuityPaymentData counter = new AnnuityPaymentData(model);
        }

        public IEnumerable<ViewModel> PaymentList()
        {

        }
    }
}
