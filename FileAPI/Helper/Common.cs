namespace FileAPI.Helper
{
    public static class Common
    {
        public static string GetCurrentDirectory()
        {
            var result = Directory.GetCurrentDirectory();
            return result;
        }
        public static string GetStaticContebntDirectory()
        {
            var result = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\StaticContent\\");
            if(!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;
        }
        public static string GetFilePath(string FileName)
        {
            var _GetStaticContebntDirectory = GetStaticContebntDirectory();  
            var result = Path.Combine(_GetStaticContebntDirectory, FileName);
            return result;
        }
    }
}
