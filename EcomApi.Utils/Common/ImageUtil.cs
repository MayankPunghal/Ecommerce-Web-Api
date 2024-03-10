namespace EcomApi.Utils.Common
{
    public class ImageUtil
    {
        public static async Task<string> SaveImage(IFormFile File)
        {
            string ImageName = new String(Path.GetFileNameWithoutExtension(File.FileName).Take(10).ToArray()).Replace(" ", "-");
            ImageName = ImageName + DateTime.Now.ToString("ttmmssfff") + Path.GetExtension(File.FileName);
            var ImagePath = AppSettings.Settings.CommonSettings.SharedFolderPath + ImageName;
            using (var fileStream = new FileStream(ImagePath, FileMode.Create))
            {
                await File.CopyToAsync(fileStream);
            }
            return ImageName;
        }
    }
}
