namespace plural.health.ViewModels
{
    public class LogoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public bool IsActive { get; set; }
        public string NavigateUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set;} = string.Empty;
    }
}
