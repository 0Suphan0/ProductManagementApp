using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        [Display(Name = "Ürün Adı")]
        public string? Name { get; set; }

        [Display(Name = "Fiyat")]
        [Range(0,1000000,ErrorMessage ="Aralık 0 ile 1.000.000 arasında olmalıdır.")]
        [Required(ErrorMessage ="Fiyat alanı gereklidir.")]
        public decimal? Price { get; set; }

        [Display(Name = "Resim")]

        public string Image { get; set;} = string.Empty;
        [Display(Name = "Aktif mı?")]

        public bool IsActive { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori alanı gereklidir.")]
        public int CategoryId { get; set; }


    }
}
