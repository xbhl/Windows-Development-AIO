using System;
using System.Diagnostics;
using System.Net.Http;
using System.IO;

namespace Windows_Development_AIO.API
{
    public class FileManager
    {
        public string Download(string url, string filePath)
        {
            if (checkFile(filePath))
            {
                return filePath;
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var fileBytes = response.Content.ReadAsByteArrayAsync().Result;
                        File.WriteAllBytes(filePath, fileBytes);
                        return filePath;
                    }
                    else
                    {
                        throw new InvalidOperationException("Failed to download the file.");
                    }
                }
            }
        }
    }
}
