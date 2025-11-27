using Microsoft.AspNetCore.Hosting;
using plural.health.Contracts;
using plural.health.Data;
using plural.health.Domian.Models;
using plural.health.Infractures.Repository;

namespace plural.health.Infractures.Repository
{
    //public class BannerRepository : IGenericRepository<Banner>
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        //private string UploadedFile(BannerViewModel request)
        //{
        //    string uniqueFileName = string.Empty;

        //    if (request.Image != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + request.Image.FileName;
        //        var FilePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(FilePath, FileMode.Create))
        //        {
        //            request.Image.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
        //private bool DeleteFile(string fileUrl)
        //{
        //    if (File.Exists(fileUrl))
        //    {
        //        File.Delete(fileUrl);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
