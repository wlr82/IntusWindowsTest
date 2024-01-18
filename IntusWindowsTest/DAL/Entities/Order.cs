using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Order : Entity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public virtual State State { get; set; }
    }
}
