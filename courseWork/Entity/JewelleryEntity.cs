namespace courseWork.Entity
{
    public class JewelleryEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public string Gemstones { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public List<BasketEntity>Baskets { get; set; }
    }
}
