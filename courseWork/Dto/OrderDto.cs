namespace courseWork.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public IEnumerable<OrderJewelleryItemDto> Jewelleries { get; set; }
    }
}
