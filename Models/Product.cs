using System.ComponentModel.DataAnnotations;

namespace BookieWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
    }
}
