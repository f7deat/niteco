using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niteco.ApplicationCore.Entities
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(1000)]
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}
