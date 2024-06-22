using TestProjectAISTown.DataContext.Entities;

namespace TestProjectAISTown.Models.BankAccountOperations
{
    /// <summary>
    /// Создание новой операции.
    /// </summary>
    public class CreateNewOperationAccountModel
    {
        /// <summary>
        /// Id банковского счёта.
        /// </summary>
        public Guid IdBankAccount { get; set; }

        /// <summary>
        /// Список типов операций.
        /// </summary>
        public List<OperationType> OperationTypes { get; set; } = [];
    }
}
