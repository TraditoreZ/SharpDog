using System;

namespace Server.IO
{
    class IOManager
    {
        public static string GetRunningFile()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static ServerConfig LogConfig()
        {
            return null;
        }



    }
}
