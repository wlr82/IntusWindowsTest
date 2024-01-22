using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class SubElement : Entity
    {
        [Required]
        public string Element { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public virtual ElementType ElementType { get; set; }
        [Required]
        public virtual Window Window { get; set; }
    }
}
