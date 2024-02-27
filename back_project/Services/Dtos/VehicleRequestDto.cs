namespace back_project.Services.Dtos
{
    public class VehicleRequestDto
    {
        public string Description { get; set; } = null!;
        public int Year { get; set; }
        public int Make { get; set; }
        public int Capacity { get; set; }
        public string? DescriptionJourney { get; set; }
        public List<int> Drivers { get; set; } = new(); 
    }
}
