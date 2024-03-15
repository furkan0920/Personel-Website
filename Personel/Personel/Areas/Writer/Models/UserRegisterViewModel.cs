using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Personel.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        //[Required(ErrorMessage="Lütfen Adini Girin")]
        public string Name { get; set; }
        //[Required(ErrorMessage="Lütfen Soyadini Girin")]
        public string Surname { get; set; }
        //[Required(ErrorMessage="Lütfen resim url değer Girin")]
        public string ImageUrl { get; set; }
        //[Required(ErrorMessage="Lütfen Kullanıcı Adini Girin")]
        public string UserName { get; set; }
       // [Required(ErrorMessage="Lütfen Şifreyi Girin")]
        public string Password { get; set; }
       // [Required(ErrorMessage="Lütfen Şifreyi Tekrar Girin")]
       // [Compare("Password",ErrorMessage ="Şifreler uyumlu değil!")]
        public string ConfirmPassword { get; set; }
       // [Required(ErrorMessage="Lütfen Mail Girin")]
        public string Mail { get; set; }
    }
}
