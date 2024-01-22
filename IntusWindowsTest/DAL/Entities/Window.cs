using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Window : Entity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int QuantityOfWindows { get; set; }

        [Required]
        public virtual Order Order { get; set; }

        public virtual ICollection<SubElement> SubElements { get; set; } = new List<SubElement>();
    }
}
