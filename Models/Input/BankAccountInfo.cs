using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestProjectAISTown.Models.Input
{
    /// <summary>
    /// Информация об банковском счёте.
    /// </summary>
    public class BankAccountInfo
    {
        /// <summary>
        /// Номер счёта.
        /// </summary>
        [NotNull]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Id владельца.
        /// </summary>
        [NotNull]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Баланс счёта.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Id валюты.
        /// </summary>
        [NotNull]
        public Guid? CurrencyId { get; set; }

        /// <summary>
        /// Id статуса.
        /// </summary>
        [NotNull]
        public Guid StatusId { get; set; }

        /// <summary>
        /// Id типов счёта.
        /// </summary>
        [NotNull]
        public Guid AccountTypeId { get; set; }
    }
}
