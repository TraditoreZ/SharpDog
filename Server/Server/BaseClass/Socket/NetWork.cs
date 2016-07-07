using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.BaseClass.Socket
{
    public abstract class NetWork
    {
        public NetWork()
        {
            
        }

        public NetWork(int listenPoint,int maxClient)
        {
            
        }

        public abstract void Start();

        public abstract void Stop();


    }
}
