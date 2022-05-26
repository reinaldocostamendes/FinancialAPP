using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entity
{
    public abstract class EntityBase<TEntity>
    {
        public Guid Id { get; set; }

        #region Validation

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();

        #endregion Validation
    }
}