using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class State : Entity
    {
        public required string Code { get; set; } = string.Empty;
    }
}
