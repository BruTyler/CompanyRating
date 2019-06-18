using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите ваше имя и фамилию")]
        [RegularExpression(@"^.* .*$", ErrorMessage = "Введите через пробел имя и фамилию")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        [Display(Name = "Имя Фамилия")]
        public string Person { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите наименование компании", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        [Display(Name = "Название организации")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите адрес компании", AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Недопустимая длина адреса")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Пожалуйста опишите что понравилось", AllowEmptyStrings = false)]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Недопустимая длина раздела \"Что понравилось\"")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Что понравилось")]
        public string PositiveMoment { get; set; }

        [Required(ErrorMessage = "Пожалуйста опишите что не понравилось", AllowEmptyStrings = false)]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Недопустимая длина раздела \"Что не понравилось\"")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Что не понравилось")]
        public string NegativeMoment { get; set; }

        [Required(ErrorMessage = "Пожалуйста оставьте общий комментарий о компании", AllowEmptyStrings = false)]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Недопустимая длина комментария")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Комментарии")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Пожалуйста дайте оценку от 1 до 5")]
        [Range(1, 5, ErrorMessage = "Недопустимая оценка")]
        [Display(Name = "Оценка")]
        public int Mark { get; set; }
    }
}
