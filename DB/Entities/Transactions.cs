namespace DB.Entities
{
    public class Transactions
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? TypeMovement { get; set; }
        public decimal Value { get; set; }
        public decimal Sald { get; set; }
        
        //foreigns
        public virtual Account? Account { get; set; }
    }
}
