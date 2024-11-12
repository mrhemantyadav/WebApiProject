namespace WebAPIProject.Models
{
    public class StudentModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public long MobileNo { get; set; } = 0;
        public string Password { get; set; } = "";
        public string Gender { get; set; } = "";
        public string SchoolName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Country { get; set; } = "";
        public string State { get; set; } = "";
    }
}
