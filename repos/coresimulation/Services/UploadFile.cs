namespace coresimulation.Services
{
    public class UploadFile
    {
        public string Upload (IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                return "No file uploaded or file is empty.";

            //extension
            List<string> files = new List<string>() { ".jpg", ".pdf", ".docx", ".json" };
            String Extension = Path.GetExtension(formFile.FileName).Trim();
            if (!files.Contains(Extension))
            {
                return $"Extension is invalid ({string.Join(",",files)})";
            }

            //File size
            if (formFile.Length > 5 * 1024 * 1024) { 
                return "File size exceeds 5 MB";
            }
            //Name changing and uploading
            //string filename = Guid.NewGuid().ToString() + Extension;
            string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            Directory.CreateDirectory(uploadDir);

            string fullPath = Path.Combine(uploadDir, formFile.FileName);

            using FileStream stream = new FileStream(fullPath, FileMode.Create);
            formFile.CopyTo(stream);

            return formFile.FileName;
        }
    }
}
