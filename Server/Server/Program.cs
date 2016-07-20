using Server.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using Server;
using Server.BaseClass;
using Server.Scripts;
using Server.BaseClass.Socket;
using Server.BaseClass.IO;

namespace Server
{
    class Program
    {
        public static ApplicationBase application;
        static void Main(string[] args)
        {
            Console.WriteLine("Server is Running....");
            ServerAssembleModel assemble = new ServerAssembleModel(args);



            // 反射
            application = new TestApplication();
            application.Start();


            NetWork server=null;
			server = new IOCPServer(8080, 1000);
            // 抽象  -读取表
			
            switch (assemble.netType)
            {
                case NetType.Tcp:
                    server = new IOCPServer(assemble.TCPPort, assemble.maxClient);
                    break;
                case NetType.Udp:
                    break;
                case NetType.Http:
                    break;
            } 
            
            Console.WriteLine(string.Format("server Port:{0}---maxClient:{1}", assemble.TCPPort, assemble.maxClient));
            LogHelper.WriteLog(typeof (Program), "服务器开启成功!");
            server.Start();



            while (true)
            {
                string key= Console.ReadLine();
                GetConsoleKey(key);
            }
            
        }

        private static void GetConsoleKey(string key)
        {
            //留做控制台I/O
        }


        ~Program()
        {
            application.Stop();
            Console.WriteLine("服务器退出");
        }
    }
}
