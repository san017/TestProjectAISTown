using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TestProjectAISTown.DataContext.Entities
{
    /// <summary>
    /// Владелец счёта.
    /// </summary>
    [Table("Customer")]
    public class Customer
    {
        /// <summary>
        /// Идентификатор владельца.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Имя.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string? LastName { get; set; }
        
        /// <summary>
        /// Отчество.
        /// </summary>
        public string? Patronymic { get; set; }
        
        /// <summary>
        /// Адрес.
        /// </summary>
        public string? Adress { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Фамилия и инициалы.
        /// </summary>
        public string? ShortName { get; set; }

        /// <summary>
        /// Список банковских счетов.
        /// </summary>
        public List<BankAccount>? BankAccounts { get; set; }
    }
}
