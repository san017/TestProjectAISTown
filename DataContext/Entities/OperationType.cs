using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectAISTown.DataContext.Entities
{
    /// <summary>
    /// Тип операций.
    /// </summary>
    [Table("OperationType")]
    public class OperationType
    {
        /// <summary>
        /// Идентификатор типа операции.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименнование типа.
        /// </summary>
        public string TypeOperationName { get; set; }
    }
}
