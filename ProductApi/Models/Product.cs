using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductApi.Models
{   [Table("products",Schema ="fdotnet")]
    public class Product{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductStatusId { get; set; }
        public string ProductStatusName { get; set; } = string.Empty;
        public string ProductUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string TitleDomestic { get; set; } = string.Empty;
        public string DescriptionDomestic { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string OtherCode { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string CurrencyName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal PriceDiscountedDomestic { get; set; }
        public decimal PriceDiscounted { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsElonkyFeatured { get; set; }
        public bool HasVideo { get; set; }
        public bool HasPersonalization { get; set; }
        public bool IsTaxable { get; set; }
        public string WhenMade { get; set; } = string.Empty;
        public string WhoMade { get; set; } = string.Empty;
        public string PersonalizationDescription { get; set; } = string.Empty;
        public bool? IsDigital { get; set; }

    }

}