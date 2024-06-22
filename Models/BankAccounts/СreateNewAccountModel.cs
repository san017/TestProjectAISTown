using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TestProjectAISTown.DataContext.Entities;

namespace TestProjectAISTown.Models.BankAccounts
{
    /// <summary>
    /// Создание нового счёта.
    /// </summary>
    public class СreateNewAccountModel
    {
        /// <summary>
        /// Список типов счёта.
        /// </summary>
        public List<AccountType> SelectAccountTypeItems { get; set; } = [];


        /// <summary>
        /// Список валют для счёта.
        /// </summary>
        public List<Currency> SelectCurrencyItems { get; set; } = [];

        /// <summary>
        /// Список людей, которые могут владеть счётом.
        /// </summary>
        public List<Customer> SelectCustomerItems { get; set; } = [];

        /// <summary>
        /// Список статусов счёта.
        /// </summary>
        public List<StatusAccount> SelectStatusAccountItems { get; set; } = [];



    }
}
