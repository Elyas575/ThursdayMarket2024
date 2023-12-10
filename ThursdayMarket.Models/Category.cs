using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }
        [Range(1, 10000)]
        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }

     
    }
}
