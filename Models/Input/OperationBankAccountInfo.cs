using TestProjectAISTown.Utilities;

namespace TestProjectAISTown.Models.Input
{
    /// <summary>
    /// Информация об операции счёта.
    /// </summary>
    public class OperationBankAccountInfo
    {
        /// <summary>
        /// Id операции.
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Наименнование операции.
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Дата операции.
        /// </summary>
        public DateTime DateOperation { get; set; }

        /// <summary>
        /// Id счёта.
        /// </summary>
        public Guid BankAccountId { get; set; }

        /// <summary>
        /// Id типа операции.
        /// </summary>
        public Guid OperationTypeId { get; set; }


    }
}
