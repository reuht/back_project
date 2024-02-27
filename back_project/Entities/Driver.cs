using back_project.Entities.Common;

namespace back_project.Entities
{
    public class Driver : EntityBase
    {
        public string FirstName { get; set; } = null!; 
        public string LastName { get; set; } = null!;
        public string Ssn { get; set; } = null!;
        public DateTime Dob {  get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }   
        public string? Zip {  get; set; }
        public int? Phone { get; set; }
        public List<Journey> Routes { get; set; } = new();
    }
}
