namespace FileAPI.Interface
{
    public interface IUploadInterface
    {
        Task<string> Upload_File(IFormFile _IFormfile);
        Task<(byte[], string, string)> DownloadFile(string FileName);
    }
}