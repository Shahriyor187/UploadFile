﻿using FileAPI.Helper;
using FileAPI.Interface;
using Microsoft.AspNetCore.StaticFiles;

namespace FileAPI.Sevice
{
    public class UploadFileService : IUploadInterface
    {
        public async Task<(byte[], string, string)> DownloadFile(string FileName)
        {
            try
            {
                var _GetFilePath = Common.GetFilePath(FileName);
                var providor = new FileExtensionContentTypeProvider();
                if(!providor.TryGetContentType(_GetFilePath, out var _ContentType)) 
                {
                    _ContentType = "application/octet-stream";
                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(_GetFilePath);
                return (_ReadAllBytesAsync, _ContentType, Path.Combine(_GetFilePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Upload_File(IFormFile _IFormfile)
        {
            string  FileName = "";
            try
            {
                FileInfo _FileInfo = new FileInfo(_IFormfile.FileName);
                FileName = _IFormfile.FileName + "_" + DateTime.Now.Ticks.ToString() + _FileInfo.Extension;
                var _GetFilePath = Common.GetFilePath(FileName);
                using (var _FileStream = new FileStream(_GetFilePath, FileMode.Create))
                {
                    await _IFormfile.CopyToAsync(_FileStream);
                }
                return FileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}