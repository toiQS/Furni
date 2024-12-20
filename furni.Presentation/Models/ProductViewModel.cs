﻿using furni.Domain.Entities;

namespace furni.Presentation.Models
{
    public class ProductViewModel
    {
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
        public List<VariantViewModel> Variants { get; set; }
    }

    public class VariantViewModel
    {
        public int ColorId { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<IFormFile> Images { get; set; }
        public int Thumbnail { get; set; }
    }

    public class SizeViewModel
    {
        public int SizeId { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
    }
}
