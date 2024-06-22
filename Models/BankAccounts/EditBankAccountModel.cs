using System.Net.NetworkInformation;
using TestProjectAISTown.DataContext.Entities;
using TestProjectAISTown.Models.BankAccounts;

namespace TestProjectAISTown.Models.BankAccounts
{
    /// <summary>
    /// Редактирование текущего счёта.
    /// </summary>
    public class EditBankAccountModel
    {
        /// <summary>
        /// Банковский счёт.
        /// </summary>
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// Список типов счёта.
        /// </summary>
        public List<AccountType> AccountTypes { get; set; } = [];

        /// <summary>
        /// Список владельцев.
        /// </summary>
        public List<Customer> Customers { get; set; } = [];

        /// <summary>
        /// Список валют.
        /// </summary>
        public List<Currency> Currencies { get; set; } = [];

        /// <summary>
        /// Список статусов.
        /// </summary>
        public List<StatusAccount> StatusAccounts { get; set; } = [];

    }
}
