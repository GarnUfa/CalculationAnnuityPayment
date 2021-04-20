using System.ComponentModel.DataAnnotations;

namespace CalculationAnnuityPayment.Models
{
    public class AnnuityPaymentModel
    {
        //Считаю уже сейчас на 20.04.21 что стоило все поля делать string (возможно не прав)
        //Так как проверять их проще
        /// <summary>
        /// 
        /// </summary>
        [Display(Name ="Сумма кредитования")]
        [Required(ErrorMessage = "Введите сумму кредитования")]
        [Range(10000, 10000000, ErrorMessage = "Введите сумму от 10000 до 10000000")]
        public decimal creditAmount { get; set; }

        [Display(Name = "Процентная ставка")]
        [Required(ErrorMessage = "Введите процентную ставку")]
        [Range(1, 100, ErrorMessage = "Неверная процентная ставка")]
        public decimal percentRate { get; set; }

        [Display(Name = "Срок кредитования")]
        [Required(ErrorMessage = "Введите срок кредитования в месяцах")]
        [Range(6, 600, ErrorMessage = "Неверный срок кредитования")]
        public string numberOfMonths { get; set; }

    }
}
