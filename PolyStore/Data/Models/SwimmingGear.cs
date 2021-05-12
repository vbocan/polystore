namespace PolyStore.Data.Models
{
    public class SwimmingGear: ProductBase
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public override string ToString() => $"[Swimming Gear] SKU: {SKU}, Brand: {Brand}, Size: {Size}, Color: {Color}";
    }
}
