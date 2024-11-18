using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeiSharpStudio.Utils
{
    internal class Tab
    {
        public static string Version { get; set; }
        public static readonly string version8 = "8.0";
        public static readonly string version8_5 = "8.5";
        public static IEnumerable<object> TabCore {  get; set; } 
    }
}
