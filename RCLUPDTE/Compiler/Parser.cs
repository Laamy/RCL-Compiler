using System;
using System.Collections.Generic;
using System.Threading;

namespace RCLUPDTE.Compiler
{
    class Parser
    {
        private int line = 0;
        private List<String> strs = new List<String>();
        private List<Integer> ints = new List<Integer>();
        public void execute(string code)
        {
            try
            {
                line = 0;
                foreach (string a in code.Split('\n'))
                {
                    line++;
                    if (a.StartsWith("print ")) Console.WriteLine(parseString(a.Substring(6)));
                    else if (a == "read") Console.Read();
                    else if (a == "clear") Console.Clear();
                    else if (a.StartsWith("pause ")) Thread.Sleep(Convert.ToInt32(a.Substring(6)));
                    else if (a.StartsWith("string ")) strs.Add(new String(a.Split(' ')[1], a.Substring(7 + a.Split(' ')[1].Length + 1)));
                    else if (a == "pause") { Console.ReadKey(); }
                }
            }
            catch
            {
                Console.WriteLine("Error'ed");
                Console.ReadKey();
            }
        }

        private string parseString(string str)
        {
            string output = str;
            output = output.Replace("\\r\\n", "\r\n");
            output = output.Replace("\\n", "\r\n");
            output = output.Replace("{line}", line.ToString());
            foreach(String newStr in strs)
                output = output.Replace("{" + newStr.parseName + "}", newStr.str);
            return output;
        }
    }
}
