using System.ComponentModel.DataAnnotations;

namespace back_project.Entities.Common
{
    public abstract class EntityBase 
    {
        [Key]
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
