using System;
using System.IO;

using RCLUPDTE.Compiler;
using RCLUPDTE.FileAssociating;

namespace RCLUPDTE
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Parser compiler = new Parser();
                compiler.execute(File.ReadAllText(args[0]));
            }
            catch
            {
                Console.WriteLine("Attempting to run Associator...");
                Associator.SelfCreateAssociation(".rcl", Associator.KeyHiveSmall.CurrentUser, "RCL Programing Language");
                Console.WriteLine("Go into the projects folder then run project.rcl :)");
                Console.ReadKey();
            }
        }
    }
}
