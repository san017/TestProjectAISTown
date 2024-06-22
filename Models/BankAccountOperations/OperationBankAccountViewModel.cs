using TestProjectAISTown.Models.Input;
using TestProjectAISTown.Utilities;

namespace TestProjectAISTown.Models.BankAccountOperations
{
    /// <summary>
    /// Банковские операции по счёту.
    /// </summary>
    public class OperationBankAccountViewModel
    {
        /// <summary>
        /// Список операций по счёту.
        /// </summary>
        public PaginatedList<OperationBankAccountInfo> OperationBankAccountInfos { get; set; }

        /// <summary>
        /// Id банковского счёта.
        /// </summary>
        public Guid BankAccountId { get; set; }
    }
}
