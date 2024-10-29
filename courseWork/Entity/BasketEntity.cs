namespace courseWork.Entity
{
    public class BasketEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public List<JewelleryEntity> Jewelleries { get; set; }
        public List<OrderEntity> Orders { get; set; }
    }
}
