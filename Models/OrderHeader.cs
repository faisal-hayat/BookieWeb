using System.ComponentModel.DataAnnotations;

namespace BookieWeb.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
    }
}
