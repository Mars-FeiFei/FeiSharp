using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeiSharpStudio;
namespace FeiSharpStudio.ClassInstance
{
    internal class ClassInfo
    {
        public string Name {  get; set; }
        public Dictionary<string,FunctionInfo> _FunctionInfo {  get; set; }
        public Dictionary<string,object> _Vars { get; set; }
        public ClassInfo(Dictionary<string,FunctionInfo> functionInfos,Dictionary<string,object> vars,string name) { 
            _FunctionInfo = new(functionInfos); _Vars = vars;Name = name;
        }
        protected virtual InstanceInfo Init(object[]? args)
        {
            return new(new());
        }
    }
}
