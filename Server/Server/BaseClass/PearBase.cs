using Server.BaseClass.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.BaseClass
{
    public abstract class PearBase
    {
        protected SocketAsyncEventArgs socketEvent;


        /// <summary>
        /// 失去连接
        /// </summary>
        public abstract void OnDisconnect();
        /// <summary>
        /// 取得消息
        /// </summary>
        public abstract void OnOperationRequest(string info, ICallBack send);


        public void SetSocketEvent(SocketAsyncEventArgs e)
        {
            socketEvent = e;
        }

    }
}
