using Server.BaseClass.Socket;
using System.Net.Sockets;

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
