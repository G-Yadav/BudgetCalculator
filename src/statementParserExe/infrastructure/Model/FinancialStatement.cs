namespace com.gaurav.main.infrastructure.Model
{
    public class FinancialStatement : BaseModel
    {
        public DateTime StatementDate { get; set; }
        public string Narration { get; set; }
        public DateTime ValueDate {get; set;}   
        public double DebitAmount {get; set;}
        public double CreditAmount { get; set; }
        public long ReferenceNumber {get; set;}
        public double ClosingBalance {get; set;}

        public override string ToString()
        {
            return $"StatementDate = {StatementDate}, Narration = {Narration}, ValueDate = {ValueDate}, DebitAmount = {DebitAmount:0.00}, CreditAmount = {CreditAmount:0.00}, ReferenceNumber = {ReferenceNumber}, ClosingBalance = {ClosingBalance:0.00}";
        }
    }
}