using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.ApplicationCore.Entities
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        [StringLength(300)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
    }
}
