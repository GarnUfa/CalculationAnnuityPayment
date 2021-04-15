using System;

namespace TestingCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal creditAmount;
            decimal percentRate;
            decimal numberOfMonths;
            Console.WriteLine("Введите сумму кредита:");
            creditAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Введите процентную ставку:");
            percentRate = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Введите срок кредитования в месяцах:");
            numberOfMonths = decimal.Parse(Console.ReadLine());
            AnnuityPaymentModel model = new AnnuityPaymentModel(creditAmount, percentRate, numberOfMonths);
            AnnuityPaymentData payment = new AnnuityPaymentData(model);

        }
    }
}
