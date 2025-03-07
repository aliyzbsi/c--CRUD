namespace ProductApi.DTOs
{
    public class ProductResponse{
        public string Title{get;set;}=string.Empty;
        public string Sku { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string TitleDomestic { get; set; } = string.Empty;
        public bool HasVideo { get; set; }
        public int Stock { get; set; }
        public string CurrencyName { get; set; } = string.Empty;
    }
    
}