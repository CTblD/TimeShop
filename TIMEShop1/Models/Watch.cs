using System.ComponentModel.DataAnnotations.Schema;

namespace TIMEShop1.Models
{
    public class Watch
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        
    }
}
