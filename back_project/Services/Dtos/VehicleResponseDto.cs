namespace back_project.Services.Dtos
{
    public class VehicleResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int Year { get; set; }
        public int Make { get; set; }
        public int Capacity { get; set; }
        public List<RouterResponseDto> Routes { get; set; } = new(); 
    }
}
