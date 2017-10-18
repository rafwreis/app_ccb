using System;
using System.IO;

namespace Instrumentos.App
{
    public class FileHelper
    {
        const string filename = "InstrumentDB.db3";

        public static string GetLocalFilePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}