﻿namespace furni.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int VariantSizeId { get; set; }

        public int OrderId { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public VariantSize VariantSize { get; set; }

        public Order Order { get; set; }
    }
}
