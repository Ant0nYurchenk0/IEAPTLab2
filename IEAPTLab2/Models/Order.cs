using IEAPTLab2.Validation;
using System.ComponentModel.DataAnnotations;

namespace IEAPTLab2.Models
{
    public class Order
    {
        public Order()
        {
            Dishes = new List<Dish>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Обов'язково вкажіть дату та час замовлення")]
        [Display(Name = "Дата та час замовлення")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime DateOrdered { get; set; }

        [MaxLength(100)]
        [Display(Name = "Коментар до замовлення")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Обов'язково вкажіть ім'я замовника")]
        [MaxLength(50)]
        [Display(Name = "Ім'я замовника")]
        public string CustomerName { get; set; }

        [Phone]
        [EmailOrPhone]
        [Display(Name = "Телефон замовника")]
        public string Phone { get; set; }

        [EmailAddress]
        [EmailOrPhone]
        [Display(Name = "Email замовника")]
        public string Email { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
