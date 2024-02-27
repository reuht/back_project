using back_project.Entities;

namespace back_project.Services.Dtos
{
    public class RouterResponseDto
    {
        public int Id { get; set; }
        public DriverResponseDto? Driver { get; set; }
        public VehicleResponseDto? Vehicle { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }

    }
}
