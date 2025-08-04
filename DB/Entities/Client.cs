namespace DB.Entities
{
    public class Client : Person
    {
        public string? Password { get; set; }
        public bool Status { get; set; }

        //foreigns
        public virtual ICollection<Account>? Accounts { get; set; }
    }
}
