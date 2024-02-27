using back_project.Entities.Common;

namespace back_project.Entities
{
    public class Journey : EntityBase
    {
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public string? Description { get; set; }
        public Driver? Driver { get; set; }
        public Vehicle? Vehicle { get; set; }
        public List<Schedule> Schedules { get; set; } = new(); 
    }
}
