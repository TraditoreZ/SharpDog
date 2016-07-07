using Mono.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using Server.IO;
using System.IO;

namespace Server.BaseClass.IO
{
    public class XmlLorder
    {
        private static Dictionary<string, SecurityElement> XmlData = new Dictionary<string, SecurityElement>();
        public static void Load(string file)
        {
            SecurityParser SP = new SecurityParser();

            // 假设xml文件路径为 Resources/test.xml
            string xmlPath = IOManager.GetRunningFile() + "\\" + file;
            Console.WriteLine("xmlPath:" + xmlPath);
            StreamReader sr = new StreamReader(xmlPath);
            SP.LoadXml(sr.ReadToEnd());

            try
            {
                SecurityElement SE = SP.ToXml();
                XmlData.Add(file, SE);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

        }

        public static string Read(string file, string childTag, string Attribute)
        {
            if (!XmlData.ContainsKey(file))
            {
                return string.Empty;
            }
            var currtXML = XmlData[file];

            foreach (SecurityElement child in currtXML.Children)
            {
                //比对下是否使自己所需要得节点
                if (child.Tag == childTag)
                {
                    //获得节点得属性
                    return child.Attribute(Attribute);
                }

            }
            return string.Empty;
        }

        public static string[] Read(string file, string childTag, string[] Attribute)
        {
            if (!XmlData.ContainsKey(file))
            {
                return null;
            }
            var currtXML = XmlData[file];

            List<string> currtData = new List<string>();
            foreach (SecurityElement child in currtXML.Children)
            {
                //比对下是否使自己所需要得节点
                if (child.Tag == childTag)
                {
                    //获得节点得属性
                    for (int i = 0; i < Attribute.Length; i++)
                    {
                        currtData.Add(child.Attribute(Attribute[i]));
                    }
                    return currtData.ToArray();
                }

            }
            return null;
        }

        public static SecurityElement ReadXML(string file)
        {
            return XmlData.ContainsKey(file) ?  XmlData[file]:null;
        }

        public static void UnLoadXml(string file)
        {
            XmlData.Remove(file);
        }

        public static void ClearAll()
        {
            XmlData.Clear();
        }



    }
}
