using PhotoCaptureApplication.DAL;
using PhotoCaptureApplication.DAL.Repositories;
using PhotoCaptureApplication.Entities.Models;
using PhotoCaptureApplication.Entities.ViewModels;

namespace PhotoCaptureApplication.BL.Repositories
{
    public class PhotoBL
    {
        public PhotoDAL _photoDAL;

        public PhotoBL(PhotoCaptureDataContext _db)
        {
            _photoDAL = new PhotoDAL(_db);
        }

        public string StoreImage(PhotoViewModel photo)
        {
            string result = string.Empty;

            try
            {
                if (photo == null || string.IsNullOrEmpty(photo.ImagePath))
                    return result = "InvalidData";

                var imageEntity = new PhotoModel
                {
                    ImagePath = photo.ImagePath,
                    Description = photo.Description,
                    DateTaken = DateTime.Now
                };

                _photoDAL.Add(imageEntity);
                _photoDAL.Save();

                result = "SavedToDB";
            }
            catch (Exception err)
            {
                result = err.Message;
            }

            return result;
        }


    }
}
