using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "ID")]
        public int ProductId { get; set; }
        [Display(Name = "Ürün Adı")]

        public string Name { get; set; }=string.Empty;
        [Display(Name = "Fiyat")]

        public decimal Price { get; set; }
        [Display(Name = "Resim")]
        public string Image { get; set;} = string.Empty;
        [Display(Name = "Satışta mı?")]

        public bool IsActive { get; set; }
        [Display(Name = "Kategori")]

        public int CategoryId { get; set; }


    }
}
