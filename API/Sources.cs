using System;
using System.Collections.Generic;

namespace Windows_Development_AIO.API
{
    public class Sources
    {
        public enum CPPFiles
        {
            vcpkg,
            mingw,
        }

        public enum CSFiles
        {
            a,
            b,
        }

        private static readonly Dictionary<Enum, string> UrlDictionary = new Dictionary<Enum, string>
        {
            { CPPFiles.vcpkg, "https://netcologne.dl.sourceforge.net/project/mingw/Installer/mingw-get-setup.exe" },
            { CPPFiles.mingw, "https://github.com/microsoft/vcpkg" },
            { CSFiles.a, "a" }, // Testing multi functionality
        };

        public static string GetSource(Enum file, Dictionary<Enum, string> dictionary = null)
        {
            Dictionary<Enum, string> sourceDictionary = dictionary ?? UrlDictionary;

            if (sourceDictionary.ContainsKey(file))
            {
                return sourceDictionary[file];
            }
            else
            {
                throw new ArgumentException("Missing file args");
            }
        }
    }
}
