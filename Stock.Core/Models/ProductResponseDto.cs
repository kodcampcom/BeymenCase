namespace Stock.Core.Models
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string VariantCode { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
    }
}
