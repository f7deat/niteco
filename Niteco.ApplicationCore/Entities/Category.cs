using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.ApplicationCore.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
