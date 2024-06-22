using TestProjectAISTown.DataContext.Entities;

namespace TestProjectAISTown.Models.BankAccountOperations
{
    /// <summary>
    /// Редактирование операции банковского счёта.
    /// </summary>
    public class EditOperationBankAccountModel
    {
        /// <summary>
        /// Операция банковского счёта.
        /// </summary>
        public OperationBankAccount OperationBankAccount { get; set; }

        /// <summary>
        /// Список типов операции.
        /// </summary>
        public List<OperationType> OperationTypes { get; set; } = [];
    }
}
