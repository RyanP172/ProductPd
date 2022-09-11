namespace ProductPd.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PriceDisplay { get; set; }
        public double PriceAmount { get; set; }
        public double PriceTotal { get; set; }
        public int Qty { get; set; }
    }
}