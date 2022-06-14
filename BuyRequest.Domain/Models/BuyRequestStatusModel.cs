using BuyRequestDomain.Entity.Enums;
using System;

namespace BuyRequestDomain.ViewModels
{
    public class BuyRequestStatusModel
    {
        public Guid Id { get; set; }
        public BuyRequestStatus BuyRequestStatus { get; set; }
    }
}