using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TestProjectAISTown.DataContext.Entities
{
    /// <summary>
    /// Типы операций.
    /// </summary>
    [Table("AccountType")]
    public class AccountType
    {
        /// <summary>
        /// Идентификатор операции.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название операции.
        /// </summary>
        [NotNull]
        public string? AccountTypeName { get; set; }

        /// <summary>
        /// Список банковских счетов.
        /// </summary>
        public List<BankAccount>? BankAccounts { get; set; }

    }
}
