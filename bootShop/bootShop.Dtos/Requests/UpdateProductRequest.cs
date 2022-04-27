using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootShop.Dtos.Requests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün Adını Boş Bırakmayın.")]
        [MinLength(3, ErrorMessage = "En Az 3 Karakter Olmalıdır.")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
