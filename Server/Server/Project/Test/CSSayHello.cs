using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Project.Test
{

    [ProtoBuf.ProtoContract]
    class CSSayHello : ProtoPackage
    {
        [ProtoBuf.ProtoMember(1)]
        public string Name { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int age { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string Say { get; set; }

    }

}
