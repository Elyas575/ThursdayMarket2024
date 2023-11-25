using System.ComponentModel.DataAnnotations;

namespace ThursdayMarket.DataAccess.DTO
{
    public class CreateCategoryDTO
    {
        [MaxLength(80,ErrorMessage ="Bro wrong character limit")]
        public string Name { get; set; }
        [Range(1, 10000, ErrorMessage ="Wrong range bro ")]
        public int DisplayOrder { get; set; }
    }
}
 