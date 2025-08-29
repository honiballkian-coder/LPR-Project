using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SolverLP_IP.Output
{
    public static class FileWriter
    {
        public static void WriteResult(string path, string content)
        {
            File.AppendAllText(path, content + "\n");
        }
    }
}
