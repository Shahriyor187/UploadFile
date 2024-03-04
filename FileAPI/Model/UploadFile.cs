using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileAPI.Model
{
    public class UploadFile
    {
        [Key, Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IFormFile File { get; set; }
    }
}
