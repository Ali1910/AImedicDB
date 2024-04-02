using howtohandelimages.Repository.Abstract;

namespace howtohandelimages.Repository.Implementation
{
    public class FileService : iFileService
    {
        private IWebHostEnvironment enviroment;
        public FileService(IWebHostEnvironment env)
        {
            this.enviroment = env;
        }
        public bool DeleteImage(string imageFileName)
        {
            try {
                var wwwpath = this.enviroment.WebRootPath;
                var path =Path.Combine(wwwpath,"Uploads\\", imageFileName);
                if (System.IO.File.Exists(path)) {
                    System.IO.File.Delete(path);
                    return true;
                        }
                return false;
            
            } catch(Exception ex)
            { 
                return false;
            }
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try {
                var contentPath=this.enviroment.ContentRootPath;
                var path = Path.Combine(contentPath, "Uploads");
                if(!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                var ext=Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", "jpeg" };
                if(!allowedExtensions.Contains(ext)) {
                    string msg = string.Format("only {0} extensions ara allowed",string.Join(",",allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                        }
                string uniqueString =Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileWithpath = Path.Combine(path, newFileName);
                var stream=new FileStream(fileWithpath,FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);
            }catch (Exception e) 
            {
                return new Tuple<int, string>(0, "error has Occured");
            }
        }
    }
}
