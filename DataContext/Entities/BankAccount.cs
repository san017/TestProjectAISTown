using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace TestProjectAISTown.DataContext.Entities
{
    /// <summary>
    /// Банковский счёт.
    /// </summary>
    [Table("BankAccount")]
    public class BankAccount
    {
        /// <summary>
        /// Идентификатор счёта.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        [NotNull]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Идентификатор владельца счёта.
        /// </summary>
        [NotNull]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Баланс счёта.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Идентификатор валюты.
        /// </summary>
        [NotNull]
        public Guid? CurrencyId { get; set; }

        /// <summary>
        /// Идентификатор статуса.
        /// </summary>
        [NotNull]
        public Guid StatusId { get; set; }

        /// <summary>
        /// Идентификатор типов счёта.
        /// </summary>
        [Required]
        public Guid AccountTypeId { get; set; }

        /// <summary>
        /// Тип счёта.
        /// </summary>
        public AccountType TypeAccount { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Владелец счёта.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Статус счёта.
        /// </summary>
        public StatusAccount Status { get; set; }

    }
}
