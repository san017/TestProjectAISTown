using Microsoft.EntityFrameworkCore;
using TestProjectAISTown.DataContext.Entities;

namespace TestProjectAISTown.DataContext
{
    /// <summary>
    /// Контекст подключения к бд.
    /// </summary>
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        { }

        /// <summary>
        /// Таблица типов счетов.
        /// </summary>
        public virtual DbSet<AccountType> AccountTypes { get; set; }

        /// <summary>
        /// Таблица банковских счетов.
        /// </summary>
        public virtual DbSet<BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// Таблица владельцев счётов.
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Таблица валют.
        /// </summary>
        public virtual DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Таблица статусов.
        /// </summary>
        public virtual DbSet<StatusAccount> StatusAccounts { get; set; }

        /// <summary>
        /// Таблица типов операций.
        /// </summary>
        public virtual DbSet<OperationType> OperationTypes { get; set; }

        /// <summary>
        /// Таблица операций банковких счетов.
        /// </summary>
        public virtual DbSet<OperationBankAccount> OperationBankAccounts { get; set; }
    }
}
