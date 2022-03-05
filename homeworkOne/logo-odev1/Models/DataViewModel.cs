using System;
using System.ComponentModel.DataAnnotations;

namespace logo_odev1.Models
{
    public class DataViewModel
    {
        [Display(Name = "Ad")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Ad girilmesi zorunludur!")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Soyad girilmesi zorunludur!")]
        public string Surname { get; set; }
        
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail girilmesi zorunludur!")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s{2,3}]+$", ErrorMessage = "Geçerli bir eposta adresi girin.")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre girilmesi zorunludur!")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Şifreniz en az bir büyük harf, bir karakter, bir sayı içermeli ve en az 8 karakter olmalı.")]
        public string Password { get; set; }
    }
}
