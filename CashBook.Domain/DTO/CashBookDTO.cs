using CashBookDomain.Entity.Enums;
using System;

namespace CashBookDomain.DTO
{
    public class CashBookDTO
    {
        public CashBookOrigin Origin { get; set; }
        public Guid OriginId { get; set; }
        public string Description { get; set; }
        public CashBookType Type { get; set; }
        public decimal Value { get; set; }
    }
}