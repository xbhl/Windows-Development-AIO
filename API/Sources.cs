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

        private static readonly Dictionary<CPPFiles, string> CppURLS = new Dictionary<CPPFiles, string>
        {
            { CPPFiles.vcpkg, "https://netcologne.dl.sourceforge.net/project/mingw/Installer/mingw-get-setup.exe" },
            { CPPFiles.mingw, "https://github.com/microsoft/vcpkg" }
        };

        public static string GetSource(CPPFiles file)
        {
            if (CppURLS.ContainsKey(file))
            {
                return CppURLS[file];
            }
            else
            {
                throw new ArgumentException("Missing file args");
            }
        }
    }
}
