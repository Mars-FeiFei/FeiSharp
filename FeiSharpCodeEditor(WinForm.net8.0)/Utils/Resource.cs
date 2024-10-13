using System.Reflection;

namespace FeiSharpCodeEditor_WinForm.net8._0_
{
    public class Resource
    {
        private static readonly string FILE_PATH = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string GetResourceFilePath(string filename)
        {
            return Path.Combine(FILE_PATH, filename);
        }
        public static T GetResourceInstance<T>(string filename)
        {
            return (T)Activator.CreateInstance(typeof(T), GetResourceFilePath(filename));
        }
        public static string GetSplit()
        {
            return "           ";
        }
        public static object GetResourceFromMethod(string expression, params object[] parameters)
        {
            string[] parts = expression.Split('.');
            string namespaceName = parts[0];
            string className = parts[1];
            string methodName = parts[2];

            Type type = Type.GetType($"{namespaceName}.{className}");
            if (type == null)
            {
                throw new ArgumentException($"Cannot find type:{namespaceName}.{className}");
            }

            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(methodName);
            if (method == null)
            {
                throw new ArgumentException($"Cannot find method:{methodName}");
            }

            return method.Invoke(instance, parameters);
        }
    }
}
