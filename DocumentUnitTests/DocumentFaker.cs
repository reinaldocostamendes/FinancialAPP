using Bogus;
using DocumentDomain.DTO;
using DocumentDomain.Entity;
using DocumentDomain.Entity.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUnitTests
{
    public class DocumentFaker
    {
        public static DocumentDTO GenerateDocDTO()
        {
            DocumentDTO document = new Faker<DocumentDTO>()
                .RuleFor(x => x.Number, x => x.Random.String(1, 256))
                .RuleFor(x => x.Date, DateTime.UtcNow)
                .RuleFor(x => x.DocumentType, x => x.PickRandom<DocumentType>())
                .RuleFor(x => x.Operation, x => x.PickRandom<Operation>())
                .RuleFor(x => x.Payed, x => x.Random.Bool())
                .RuleFor(x => x.PaymentDate, DateTime.UtcNow)
                .RuleFor(x => x.Description, x => x.Random.String(1, 256))
                .RuleFor(x => x.Total, x => x.Random.Decimal(1, 1000))
                .RuleFor(x => x.Observation, x => x.Random.String(1, 256));
            return document;
        }

        public static Document GenerateDoc()
        {
            Document document = new Faker<Document>()
                 .RuleFor(x => x.Id, Guid.NewGuid())
                 .RuleFor(x => x.Number, x => x.Random.String(1, 256))
                 .RuleFor(x => x.Date, DateTime.UtcNow)
                 .RuleFor(x => x.DocumentType, x => x.PickRandom<DocumentType>())
                 .RuleFor(x => x.Operation, x => x.PickRandom<Operation>())
                 .RuleFor(x => x.Payed, x => x.Random.Bool())
                 .RuleFor(x => x.PaymentDate, DateTime.UtcNow)
                 .RuleFor(x => x.Description, x => x.Random.String(1, 256))
                 .RuleFor(x => x.Total, x => x.Random.Decimal(1, 1000))
                 .RuleFor(x => x.Observation, x => x.Random.String(1, 256));

            return document;
        }
    }
}