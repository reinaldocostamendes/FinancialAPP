using Infrastructure.Entity;
using System.Collections.Generic;

namespace CashBookDomain.ViewModels
{
    public class CashBookModel
    {
        public List<CashBook> Models { get; set; }
        public decimal Total { get; set; }
    }
}