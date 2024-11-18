using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DeveloperCommandLine.FindResorce
{
    internal class Resource
    {
        public string PATH_DERICTORY_PROJECT = "";

        public Resource(FrameworkType frameworkType)
        {
            if (frameworkType == (FrameworkType)0)
            {
                PATH_DERICTORY_PROJECT = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName;
            }
            else
            {
                PATH_DERICTORY_PROJECT = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            }
        }
        public override string ToString()
        {
            return PATH_DERICTORY_PROJECT + ".Combine(string path)";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Resource)
            {
                return false;
            }
            if (obj is Resource r)
            {
                return r.PATH_DERICTORY_PROJECT == PATH_DERICTORY_PROJECT;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return PATH_DERICTORY_PROJECT.Length;
        }
        public string GetString(string name)
        {
            return File.ReadAllText(Path.Combine(PATH_DERICTORY_PROJECT, name));
        }
    }
    internal enum FrameworkType
    {
        Dotnet678,
        DotnetCoreOrFramework
    }
}
