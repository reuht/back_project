using back_project.Entities.Common;

namespace back_project.Entities
{
    public class Schedule : EntityBase
    {
        public int RouteId { get; set; }
        public int WeekNum { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Journey? Route { get; set; }
    }
}
