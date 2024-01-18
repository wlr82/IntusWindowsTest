using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class State : Entity
    {
        [Required]
        public string Code { get; set; }
    }
}
