namespace AC2
{
    public class Comarca
    {
        public int Year { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
        public int Population { get; set; }
        public int DomesticExpense { get; set; }
        public int EconomicalActivitiesExpense { get; set; }
        public int Total { get; set; }
        public decimal IndividualExpense { get; set; }

        public override string ToString()
        {
            return $"Year: {Year}, Code: {Code}, Name: {Name}, Population: {Population}, Domestic Expense: {DomesticExpense}, Economical Activities Expense: {EconomicalActivitiesExpense}, Total: {Total}, Individual Expense: {IndividualExpense}";
        }
    }
}
