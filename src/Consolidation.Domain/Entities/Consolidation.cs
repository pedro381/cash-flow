namespace Consolidation.Domain.Entities
{
    public class Consolidation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal TotalDebits { get; set; }
        public decimal Balance { get; set; }
        public Enums.ConsolidationType Type { get; set; }

        public Consolidation() { }

        public Consolidation(DateTime date, decimal totalCredits, decimal totalDebits, Enums.ConsolidationType type)
        {
            Date = date;
            TotalCredits = totalCredits;
            TotalDebits = totalDebits;
            Balance = totalCredits - totalDebits;
            Type = type;
        }
    }
}
