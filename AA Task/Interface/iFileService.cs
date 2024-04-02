namespace howtohandelimages.Repository.Abstract
{
    public interface iFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
