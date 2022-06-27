using Bogus;
using CashBookDomain.DTO;
using CashBookDomain.Entity;
using CashBookDomain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsRabbitMQ
{
    public class CashBooktFaker
    {
        public static CashBookDTO GenerateBCashBookDTO()
        {
            CashBookDTO cashBookDTO = new Faker<CashBookDTO>()
           .RuleFor(x => x.Origin, x => x.PickRandom<CashBookOrigin>())
           .RuleFor(x => x.OriginId, Guid.NewGuid())
           .RuleFor(x => x.Description, x => x.Random.String(1, 256))
           .RuleFor(x => x.Type, x => x.PickRandom<CashBookType>())
           .RuleFor(x => x.Value, x => x.Random.Decimal(1, 200));

            return cashBookDTO;
        }

        public static CashBook GenerateCashBook()
        {
            CashBook cashBook = new Faker<CashBook>()
                .RuleFor(x => x.Id, Guid.NewGuid())
                .RuleFor(x => x.Origin, x => x.PickRandom<CashBookOrigin>())
                .RuleFor(x => x.OriginId, Guid.NewGuid())
                .RuleFor(x => x.Description, x => x.Random.String(1, 256))
                .RuleFor(x => x.Type, x => x.PickRandom<CashBookType>())
                .RuleFor(x => x.Value, x => x.Random.Decimal(1, 200));

            return cashBook;
        }
    }
}