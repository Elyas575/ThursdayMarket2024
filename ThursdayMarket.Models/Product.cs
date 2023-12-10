using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayMarket.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Range(1,1000)]

        public double Price { get; set; }
        [Range(1, 1000)]

        public double DiscountPrice { get; set; }
        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
