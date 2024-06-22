using TestProjectAISTown.DataContext.Entities;

namespace TestProjectAISTown.Models.BankAccounts
{
    /// <summary>
    ///Банковский счёт.
    /// </summary>
    public class BankAccountViewModel
    {
        /// <summary>
        /// Id банковского счёта.
        /// </summary>
        public Guid IdBankAccount { get; set; }

        /// <summary>
        /// Номер счёта.
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Баланс счёта.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Наименнование типа счёта.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Наименнование валюты счёта.
        /// </summary>
        public string CurrencyName { get; set; }

        /// <summary>
        /// Наименнование владельца счёта.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Наименнование статуса счёта.
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Поисковое значение номера счёта.
        /// </summary>
        public string SearchString { get; set; }
    }
}
