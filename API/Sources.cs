using System;

namespace Windows_Development_AIO.API
{
    public class CPP
    {
        public enum Files
        {
            vcpkg,
            mingw,
        }

        public static string GetSource(Files file)
        {
            switch (file)
            {
                case Files.vcpkg:
                    return "https://netcologne.dl.sourceforge.net/project/mingw/Installer/mingw-get-setup.exe";
                case Files.mingw:
                    return "https://github.com/microsoft/vcpkg";
                default:
                    throw new ArgumentException("Missing file args");
            }
        }
    }
}
