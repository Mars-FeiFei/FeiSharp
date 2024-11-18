using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharpStudio
{
    public class FunctionInfo
    {
        public string Name { get; internal set; }
        public List<string> Parameter { get; internal set; }
        public List<Token> FunctionBody { get; internal set; }
        public FunctionInfo(string name, IEnumerable<string> parameter, List<Token> functionBody)
        {
            Name = name;
            Parameter = new(parameter);
            FunctionBody = functionBody;
        }
    }
    public class OutputEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public OutputEventArgs(string message, string type = "info")
        {
            Message = message;
            Type = type;
        }
    }
}
