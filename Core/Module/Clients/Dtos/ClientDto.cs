using Shared.Enum;

namespace Core.Module.Clients.Dtos
{
    public class ClientDto
    {
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string? Identity { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public bool Status { get; set; }
    }
}
