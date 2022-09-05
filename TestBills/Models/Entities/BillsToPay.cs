using System;

namespace TestBills.Models.Entities
{
    public class BillsToPay
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public double OriginalValue { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PayDay { get; set; }
    }
}
