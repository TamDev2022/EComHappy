using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SixLabors.ImageSharp;

namespace Application.Service
{
    public class FileService
    {
        private readonly string extension = ".webp";
        private static readonly List<string> ImageExtensions =
            new() { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public FileService()
        {
        }

        public Tuple<bool, string?> IsImageFile(IFormFile file)
        {
            var isFile = ImageExtensions.Contains(Path.GetExtension(file.FileName).ToUpperInvariant());
            var message = "Accept file is [ " + String.Join(", ", ImageExtensions) + " ]";
            return Tuple.Create(isFile, isFile ? null : message);
        }
        public string GenarateFileNameWebp(string fileName)
        {
            var rg = Regex.Replace(fileName, @"[^\u0000-\u007F]+", string.Empty);
            fileName = Path.GetFileNameWithoutExtension(rg);
            string prefix = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            return prefix + fileName + extension;
        }

        public Task<byte[]> GetFileAsync(string fileName)
        {
            throw new ArgumentException();
        }
        public async Task UploadFileAsync(Stream file, string fileName)
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //var root = _env.WebRootPath;
            //var path = Path.Combine(root, rootFile, fileName);
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await ConvertToWebpAsync(file, stream);
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var NewFileName = GenarateFileNameWebp(file.FileName);
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, NewFileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await ConvertToWebpAsync(file.OpenReadStream(), stream);
            }

            return fullPath;
        }

        public async Task ConvertToWebpAsync(Stream _in, Stream _out)
        {
            using (var temp = new MemoryStream())
            {
                await _in.CopyToAsync(temp);
                using (Image image = Image.Load(temp.ToArray()))
                {
                    await image.SaveAsWebpAsync(_out); // Automatic encoder selected based on extension.
                }
            }
        }
    }
}
