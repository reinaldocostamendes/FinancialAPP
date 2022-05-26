using Infrastructure.Entity.Enums;
using System;

namespace DocumentDomain.DTO
{
    public class DocumentDTO
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DocumentType DocumentType { get; set; }
        public Operation Operation { get; set; }
        public bool Payed { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }

        public string Observation { get; set; }
    }
}