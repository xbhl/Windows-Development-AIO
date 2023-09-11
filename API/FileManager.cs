using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace Windows_Development_AIO.API
{
    public class FileManager
    {

        private string CreateDirectory(string name)
        {
            string directory = Path.Combine(Directory.GetCurrentDirectory(), $"{name}");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return directory;
        }

        public async Task<string> Download(string url, string fileName)
        {
            string downloadDirectory = CreateDirectory("DownloadTemp");

            string fullFilePath = Path.Combine(downloadDirectory, fileName);

            if (File.Exists(fullFilePath))
            {
                return fullFilePath;
            }
            else {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            var fileBytes = await response.Content.ReadAsByteArrayAsync();
                            await File.WriteAllBytesAsync(fullFilePath, fileBytes);
                            return fullFilePath;
                        }
                        else
                        {
                            throw new InvalidOperationException($"Failed to download the file. Status code: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("An error occurred while downloading the file.", ex);
                    }
                }
            }
        }
    }

}
