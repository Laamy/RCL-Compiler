using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLUPDTE.Compiler
{
    struct String
    {
        public string parseName;
        public string str;
        public String(string parseName, string str)
        {
            this.parseName = parseName;
            this.str = str;
        }
    }
    struct Integer
    {
        public string parseName;
        public int integer;
        public Integer(string parseName, int integer)
        {
            this.parseName = parseName;
            this.integer = integer;
        }
    }
}
