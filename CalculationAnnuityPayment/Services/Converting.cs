using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationAnnuityPayment.Services
{
    public static class Converting
    {
        public static decimal ByMonth(this decimal percent) => (percent / 12);
        public static decimal PercentNumerical(this decimal percent) => (percent / 100);
        public static decimal Round(this decimal doub, int i) => Math.Round((decimal)doub, i);

    }
}
