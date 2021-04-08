using System;
using System.Collections.Generic;
using System.Text;

namespace TestingCalculation
{
    public static class Converting
    {
        public static decimal ByMonth(this decimal percent) => Math.Round((percent / 12),3);
        public static decimal ToDouble(this decimal percent) => (percent / 100).Round();
        public static decimal Round(this decimal doub) => Math.Round(doub, 3);

    }
}
