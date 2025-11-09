namespace SchoolManagement.Models
{
    public class ExpenseModel
    {
        public int ID { get; set; }
        public string ExpenseType { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
