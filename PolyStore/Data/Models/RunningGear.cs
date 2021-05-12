namespace PolyStore.Data.Models
{
    public class RunningGear: ProductBase
    {
        public string FootSize { get; set; }
        public string Color { get; set; }
        public override string ToString() => $"[Running Gear] SKU: {SKU}, Brand: {Brand}, Foot Size: {FootSize}, Color: {Color}";
    }
}
