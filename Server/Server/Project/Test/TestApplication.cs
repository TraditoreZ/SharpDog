using Server.BaseClass;

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
