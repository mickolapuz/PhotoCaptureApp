using Microsoft.AspNetCore.Mvc;
using PhotoCaptureApplication.Entities.Models;
using PhotoCaptureApplication.DAL;
using PhotoCaptureApplication.BL.Repositories;
using PhotoCaptureApplication.BL;
using PhotoCaptureApplication.Entities.ViewModels;

namespace PhotoCaptureApplication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PhotoController : Controller
    {
        private PhotoBL _photoBL;

        public PhotoController(PhotoCaptureDataContext db)
        {
            _photoBL = new PhotoBL(db);
        }

        [HttpPost("saveImage")]
        public IActionResult SaveImage([FromBody] PhotoViewModel photo)
        {
            string result = _photoBL.StoreImage(photo);
            return Ok(result);
        }

    }
}
