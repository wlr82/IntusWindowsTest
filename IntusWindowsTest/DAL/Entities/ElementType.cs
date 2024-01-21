using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ElementType : Entity
    {
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
