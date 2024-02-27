using back_project.Entities.Common;

namespace back_project.Entities
{
    public class Vehicle : EntityBase
    {
        public string Description { get; set; } = null!; 
        public int Year { get; set; }
        public int Make { get; set; }
        public int Capacity { get; set; }
        public List<Journey> Routes { get; set; } = new(); 
    }
}
