using Server.BaseClass.IO;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security;
using System.Text;
using Server.BaseClass;
using System.Reflection;
using Server.IO;

namespace Server
{
    public enum NetType
    {
        Tcp = 0,
        Udp = 1,
        Http = 2
    }

    public class ServerAssembleModel
    {
        private SecurityElement serverConfig;
        private int appCount = 0;
        private string serverVersion;
        private string serverName;
        public int maxClient;

        //TCP
        public int TCPPort;
        public string TCPAddress;
        public int TCPInactivityTimeout;

        //App
        private string appFilePaht;
        private string appType;
        private string MainApp;
        public NetType netType;

        public ServerAssembleModel()
        {
            Instance();
        }

        public ServerAssembleModel(string[] args)

        {
            Instance();
        }


        private void Instance()
        {
            //加载配置文件  释放  存储到本地
            XmlLorder.Load("ServerConfig.config");
            serverConfig = XmlLorder.ReadXML("ServerConfig.config");
            XmlLorder.UnLoadXml("ServerConfig.config");
            List<SecurityElement> applications = new List<SecurityElement>();
            foreach (SecurityElement child in serverConfig.Children)
            {
                if (child.Tag == "server")
                {
                    serverVersion = child.Attribute("version");
                    serverName = child.Attribute("name");
                    Console.WriteLine("Server Name:" + serverName);
                    Console.WriteLine("Version:" + serverVersion);
                }

                if (child.Tag == "SharpDog")
                {
                    appCount = child.Children.Count;
                    Console.WriteLine("AppCount:" + appCount);
                    for (int i = 0; i < appCount; i++)
                    {
                        var currtXml = child.Children[i] as SecurityElement;
                        Console.WriteLine("[" + i + "]App:" + currtXml.Tag);
                        applications.Add(currtXml);
                    }
                }

            }
            Console.WriteLine("Please Selete Application On The Server!");
            string key = string.Empty;
            int ikey = -1;
            do
            {
                key = Console.ReadLine();
            } while (!int.TryParse(key, out ikey) || ikey < 0 || ikey > applications.Count); //必须输入正确的APP ID 才能执行下一步

            var currtApp = applications[ikey];
            maxClient = int.Parse(currtApp.Attribute("MaxClient"));
            foreach (SecurityElement child in currtApp.Children)
            {
                if (child.Tag == "TCPListeners")
                {
                    TCPPort = int.Parse(child.Attribute("Port"));
                    TCPAddress = child.Attribute("IPAddress");
                    TCPInactivityTimeout = int.Parse(child.Attribute("InactivityTimeout"));
                }
                if (child.Tag == "UDPListeners")
                {

                }
                if (child.Tag == "HTTPListeners")
                {

                }
                if (child.Tag == "Application")
                {
                    appFilePaht = child.Attribute("FilePath");
                    appType = child.Attribute("Type");
                    MainApp = child.Attribute("MainApp");
                    netType = (NetType)Enum.Parse(typeof(NetType), child.Attribute("NetType"));
                }

            }




        }

        public ApplicationBase GetApplication()
        {
            string path = IOManager.GetRunningFile() + "\\Project\\" + appFilePaht + "\\" + MainApp;
            Console.WriteLine("AppPath:" + path);
            Assembly assembly = Assembly.LoadFile(path);
            Console.WriteLine(assembly.GetName());
            //Type type = assembly.GetType(appType);
            //return assembly.CreateInstance(appType) as ApplicationBase;
            return null;
        }


    }
}
