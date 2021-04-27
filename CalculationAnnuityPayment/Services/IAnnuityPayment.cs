using CalculationAnnuityPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment.Services
{
    public interface IAnnuityPayment
    {
        public IEnumerable<ViewModel> PaymentList();
    }
}
