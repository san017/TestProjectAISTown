using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectAISTown.DataContext.Entities
{
    /// <summary>
    /// Операция банковского счёта.
    /// </summary>
    [Table("OperationBankAccount")]
    public class OperationBankAccount
    {
        /// <summary>
        /// Идентификатор операции.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор типа операции.
        /// </summary>
        public Guid OperationTypeId { get; set; }

        /// <summary>
        /// Идентификатор банковского счёта.
        /// </summary>
        public Guid BankAccountId { get; set; }

        /// <summary>
        /// Дата операции.
        /// </summary>
        public DateTime DateOperation { get; set; }

        /// <summary>
        /// Тип операции.
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Банковский счёт.
        /// </summary>
        public BankAccount BankAccount { get; set; }
    }
}
