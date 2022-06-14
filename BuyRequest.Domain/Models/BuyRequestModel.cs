using BuyRequestDomain.Entity;
using BuyRequestDomain.Entity.Enums;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BuyRequestDomain.ViewModels
{
    public class BuyRequestModel
    {
        public Guid Id { get; set; }
        public long Code { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public List<Product> Products { get; set; }
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