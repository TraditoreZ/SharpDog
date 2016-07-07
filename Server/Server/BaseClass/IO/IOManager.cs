using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.IO
{
    class IOManager
    {
        public static string GetRunningFile()
        {
            return Environment.CurrentDirectory;
        }

        public static ServerConfig LogConfig()
        {
            return null;
        }



    }
}
