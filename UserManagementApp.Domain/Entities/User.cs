namespace UserManagementApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CNIC { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
