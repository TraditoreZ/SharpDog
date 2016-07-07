using Server.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.BaseClass;
using Server.Scripts;

namespace Server
{
    class Program
    {
        public static ApplicationBase application;
        static void Main(string[] args)
        {
            Console.WriteLine("Server is Running....");

            application = new TestApplication();
            application.Start();

            // 抽象
            IOCPServer server = new IOCPServer(8088, 1024);
            server.Start();




            Console.ReadLine();
        }




        ~Program()
        {
            application.Stop();
            Console.WriteLine("服务器退出");
        }
    }
}
