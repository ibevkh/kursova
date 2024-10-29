namespace courseWork.Entity
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public List<BasketEntity> Baskets { get; set; }
        public ClientEntity Client { get; set; }
    }
}
