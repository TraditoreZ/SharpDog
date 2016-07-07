using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress remote = IPAddress.Parse("127.0.0.1");
            client c = new client(8080, remote);

            c.connect();
            Console.WriteLine("服务器连接成功!");
            int x = 0;
            while (true)
            {
                Console.Write("send>");
                //string msg = Console.ReadLine();
                //if (msg == "exit")
                c.send("Send Message:"+x++);
                //c.Receive();
                System.Threading.Thread.Sleep(1000);
                
            }
            c.disconnect();
            Console.ReadLine();
        }
    }
}
