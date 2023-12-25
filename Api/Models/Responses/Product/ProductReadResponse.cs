﻿namespace ECommerceApi.Models.Responses.Product
{
    public class ProductReadResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
