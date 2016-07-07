using Server.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Scripts
{
   public class TestApplication : ApplicationBase
    {
        public override PearBase CreatePear()
        {
            return new TestPear();
        }

        public override void Start()
        {
           
        }

        public override void Stop()
        {
            
        }
    }
}
