using System;
using System.Collections.Generic;
using System.Text;

namespace TestingCalculation
{
    public static class Converting
    {
        public static decimal ByMonth(this decimal percent) => (percent / 12);
        public static decimal ToDouble(this decimal percent) => (percent / 100);
        public static decimal Round(this decimal doub, int i) => Math.Round(doub, i);

    }
}
