using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.BaseClass
{
    public abstract class ApplicationBase
    {
        public abstract void Start();

        public abstract void Stop();

        public abstract PearBase CreatePear();


    }
}
