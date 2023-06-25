using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookieWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =5)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage ="values must be b/w 1 and 100")]
        [DisplayName("Display Order")]
        public int DisplayOrders { get; set; }
    }
}
