using Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace DB.Entities
{
    public class Person
    {
        [Key]
        public string? IdentityDocument { get; set; }
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Phone {  get; set; }
    }
}
