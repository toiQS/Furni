﻿using furni.Domain.Entities;

namespace furni.Presentation.Models
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public float PriceSale { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public Label Label { get; set; } = 0;
        public bool IsFeatured { get; set; }
        public string? Slug { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public List<UpdateVariantViewModel> Variants { get; set; }
    }

    public class UpdateVariantViewModel
    {
        public int VariantId { get; set; }
        public int ColorId { get; set; }
        public List<UpdateSizeViewModel> Sizes { get; set; }
        public List<IFormFile> Images { get; set; }
        public int Thumbnail { get; set; }
    }

    public class UpdateSizeViewModel
    {
        public int SizeId { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
    }
}
