using static TIMEShop1.Models.Watch;

namespace TIMEShop1.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int WatchId { get; set; }
        public Watch Watch { get; set; } = new Watch();
        public int Quantity { get; set; }
    }
}
