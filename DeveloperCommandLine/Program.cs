using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
internal static class Utils
{
    public static bool IgnoreEquals(this string a, string b)
    {
        return a.Equals(b,StringComparison.OrdinalIgnoreCase);
    }
    public static bool IgnoreContains(this string str, string str1)
    {
        string a = str.ToUpperInvariant();
        string b = str.ToUpperInvariant();
        return a.Contains(b);
    }
}
internal class Program
{
    static readonly StringComparison mode = StringComparison.OrdinalIgnoreCase;
    private static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.Write(Directory.GetCurrentDirectory() + ">");
                
                string arguments = Console.ReadLine();
                if (arguments.Equals("cd..",mode))
                {
                    Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).FullName);
                    Console.WriteLine();
                }
                else if (arguments.Contains("cd"))
                {
                    Directory.SetCurrentDirectory(arguments.Split(' ')[1]);
                    Console.WriteLine();
                }
                else if (arguments[1] == ':')
                {
                    Directory.SetCurrentDirectory(arguments);
                    Console.WriteLine();
                }
                else if (arguments.Contains("fss"))
                {
                    string[] arg = arguments.Split(' ');
                    List<string> strings = new(arg);
                    strings.Remove("fss");
                    bool isFileCommand = false;
                    bool isFileCommandAndFileNameWhere = false;
                    foreach (string s in strings) {
                        if (s.Equals("reload"))
                        {
                            Console.WriteLine("reloading......");
                            Thread.Sleep(1000);
                            Console.Clear();
                            continue;
                        }
                        else if (s.Equals("file"))
                        {
                            isFileCommand = true;
                            continue;
                        }
                        else if (s.Equals("all") && isFileCommand)
                        {
                            Process process1 = new Process();
                            process1.StartInfo.FileName = "cmd.exe";
                            process1.StartInfo.Arguments = "/c dir /s";
                            process1.StartInfo.RedirectStandardOutput = true;
                            process1.StartInfo.UseShellExecute = false;
                            process1.Start();
                            string output1 = process1.StandardOutput.ReadToEnd();
                            Console.WriteLine(output1);
                            process1.WaitForExit();
                            isFileCommand = false;
                            continue;
                        }
                        else if (s.Equals("filename"))
                        {
                            isFileCommandAndFileNameWhere = true;
                            continue;
                        }
                        else if (s.Contains("extension") && isFileCommandAndFileNameWhere)
                        {
                            Process process1 = new Process();
                            process1.StartInfo.FileName = "cmd.exe";
                            process1.StartInfo.Arguments = $"/c dir *.{s.Split('"')[1].Split('"')[0]}";
                            process1.StartInfo.RedirectStandardOutput = true;
                            process1.StartInfo.UseShellExecute = false;
                            process1.Start();
                            string output1 = process1.StandardOutput.ReadToEnd();
                            Console.WriteLine(output1);
                            process1.WaitForExit();
                            isFileCommandAndFileNameWhere = false;
                            continue;
                        }
                        else if (s.Contains("all") && isFileCommandAndFileNameWhere)
                        {
                            Process process1 = new Process();
                            process1.StartInfo.FileName = "cmd.exe";
                            process1.StartInfo.Arguments = $"/c where {s.Split('"')[1].Split('"')[0]}";
                            process1.StartInfo.RedirectStandardOutput = true;
                            process1.StartInfo.UseShellExecute = false;
                            process1.Start();
                            string output1 = process1.StandardOutput.ReadToEnd();
                            Console.WriteLine(output1);
                            process1.WaitForExit();
                            isFileCommandAndFileNameWhere = false;
                            continue;
                        }
                        else if (s.Contains("new"))
                        {
                            Process.Start("cmd.exe");
                        }
                    }
                }
                else
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = $"/c {arguments}";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);
                    process.WaitForExit();
                }
            }
            catch
            {
                Console.WriteLine();
                continue;
            }
        }
    }
}

