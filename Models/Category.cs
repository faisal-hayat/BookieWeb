using System.ComponentModel.DataAnnotations;

namespace BookieWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int DisplayOrders { get; set; }
    }
}
