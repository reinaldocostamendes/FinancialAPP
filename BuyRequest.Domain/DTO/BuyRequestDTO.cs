using Infrastructure.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BuyRequestDomain.DTO
{
    public class BuyRequestDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public long Code { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<ProductDTO> Products { get; set; }
        public Guid Client { get; set; }
        public string ClientDescription { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public BuyRequestStatus Status { get; set; }
        public string Street { get; set; }

        public string StreetNumber { get; set; }
        public string Sector { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal ProductsValues => Products.Sum(p => p.Value * p.Quantity);
        public decimal Discount { get; set; }
        public decimal CostValue { get; set; }
        public decimal TotalValue => ProductsValues - Discount;
    }
}