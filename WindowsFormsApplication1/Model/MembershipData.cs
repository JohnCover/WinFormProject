using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Provides file read and write mechanism for member class
    /// </summary>
    class MembershipData
    {
        public static string[] GetMemberships(String path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }

        public static void SaveMemberships(string path, string[] data)
        {
            File.WriteAllLines(path, data);
        }
    }
}
