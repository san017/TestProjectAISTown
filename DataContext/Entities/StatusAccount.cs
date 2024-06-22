using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectAISTown.DataContext.Entities
{
    /// <summary>
    /// Статус счёта.
    /// </summary>
    [Table("StatusAccount")]
    public class StatusAccount
    {
        /// <summary>
        /// Идентификатор счёта.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименнование статуса.
        /// </summary>
        public string? StatusName { get; set; }

        /// <summary>
        /// Список банковских счетов.
        /// </summary>
        public List<BankAccount>? BankAccounts { get; set; }
    }
}
