using Infrastructure.Entity.Enums;
using System;

namespace BuyRequestDomain.ViewModels
{
    public class BuyRequestStatusViewModel
    {
        public Guid Id { get; set; }
        public BuyRequestStatus BuyRequestStatus { get; set; }
    }
}