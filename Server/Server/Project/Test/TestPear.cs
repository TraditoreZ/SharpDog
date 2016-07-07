using Server.BaseClass;
using Server.BaseClass.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Scripts
{
    public class TestPear : PearBase
    {
        public override void OnDisconnect()
        {
            
        }

        public override void OnOperationRequest(string info,ICallBack send)
        {
            Console.WriteLine("Test:"+info);
            string re = "服务器返回信息！";
            send.Send(socketEvent, Encoding.UTF8.GetBytes(re));
        }
    }
}
