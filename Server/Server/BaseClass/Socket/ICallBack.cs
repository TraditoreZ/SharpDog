﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.BaseClass.Socket
{
    public interface ICallBack
    {
        void Send(SocketAsyncEventArgs e, byte[] data);
    }
}
