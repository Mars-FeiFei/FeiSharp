using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharpStudio.ClassInstance
{
    internal class InstanceInfo
    {
        public Dictionary<string,object> Properties = new Dictionary<string,object>();
        public InstanceInfo(Dictionary<string, object> properties)
        {
            Properties = properties;
        }
    }
}
