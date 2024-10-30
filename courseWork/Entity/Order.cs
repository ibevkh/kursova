﻿namespace courseWork.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderJewelleries> OrderJewelleries { get; set; }
    }
}
