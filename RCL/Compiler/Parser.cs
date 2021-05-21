using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCL.Compiler
{
    class Parser
    {
        public void execute(string code)
        {
            foreach (string a in code.Split('\n'))
            {
                if (a.StartsWith("print "))
                {
                    Console.Write(a.Substring(6));
                }
                else if (a == "read")
                {
                    Console.Read();
                }
            }
        }
    }
}
