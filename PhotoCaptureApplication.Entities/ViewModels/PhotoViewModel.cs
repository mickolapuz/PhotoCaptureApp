using System.ComponentModel.DataAnnotations;

namespace PhotoCaptureApplication.Entities.ViewModels
{
    public class PhotoViewModel
    {
        [Key]
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
    }
}