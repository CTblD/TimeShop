namespace TIMEShop1.ViewModels
{
    public class EditWatchViewModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string? URL { get; set; }
    }
}
