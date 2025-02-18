using Transactions.Domain.Enums;

namespace Transactions.Api.DTOs
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
    }
}
