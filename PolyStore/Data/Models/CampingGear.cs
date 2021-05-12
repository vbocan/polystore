namespace PolyStore.Data.Models
{
    public class CampingGear : ProductBase
    {
        public string TentSize { get; set; }
        public int NumberOfRooms { get; set; }
        public string WallColor { get; set; }
        public string CeilingColor { get; set; }
        public override string ToString() => $"[Camping Gear] SKU: {SKU}, Brand: {Brand}, Size: {TentSize}, Rooms: {NumberOfRooms}, WallColor: {WallColor}, CeilingColor: {CeilingColor}";
    }
}
