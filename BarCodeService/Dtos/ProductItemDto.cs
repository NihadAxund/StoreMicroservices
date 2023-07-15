namespace BarCodeService.Dtos
{
    public class ProductItemDto
    {
        public int ProductId { get; set; }
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        public string? ProductName { get; set; }

        public override string ToString()
        {
            return $"12345:{ProductId}-{Volume}";
        }
    }//1234567890
}
