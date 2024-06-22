using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectAISTown.DataContext.Entities
{
    /// <summary>
    /// Валюта.
    /// </summary>
    [Table("Currency")]
    public class Currency
    {
        /// <summary>
        /// Идентификатор валюты.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименнование валюты.
        /// </summary>
        public string? NameCurrency { get; set; }

        /// <summary>
        /// Список банковских счетов.
        /// </summary>
        public List<BankAccount>? BankAccounts { get; set; }
    }
}
