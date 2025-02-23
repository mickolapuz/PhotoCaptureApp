using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoCaptureApplication.Entities.Models
{
    [Table("TblPhotos")]
    public class PhotoModel
    {
        [Key]
        public int PhotoID { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public DateTime DateTaken { get; set; }
    }
}