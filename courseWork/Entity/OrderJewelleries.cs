namespace courseWork.Entity
{
    public class OrderJewelleries
    {
        public int OrderId { get; set; }
        public int JewelleryId { get; set; }
        public int Quantity { get; set; }
        public Jewellery Jewellery { get; set; }
        public Order Order { get; set; }
    }
}
