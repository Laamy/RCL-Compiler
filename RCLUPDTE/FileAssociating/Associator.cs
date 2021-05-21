using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLUPDTE.FileAssociating
{
    class Associator
    {
        public enum KeyHiveSmall
        {
            ClassesRoot,
            CurrentUser,
            LocalMachine,
        }

        public static void CreateAssociation(string ProgID, string extension, string description, string application, string icon, KeyHiveSmall hive = KeyHiveSmall.CurrentUser)
        {
            RegistryKey selectedKey = null;

            switch (hive)
            {
                case KeyHiveSmall.ClassesRoot:
                    Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(extension).SetValue("", ProgID);
                    selectedKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(ProgID);
                    break;

                case KeyHiveSmall.CurrentUser:
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Classes\" + extension).SetValue("", ProgID);
                    selectedKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Classes\" + ProgID);
                    break;

                case KeyHiveSmall.LocalMachine:
                    Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Classes\" + extension).SetValue("", ProgID);
                    selectedKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Classes\" + ProgID);
                    break;
            }

            if (selectedKey != null)
            {
                if (description != null)
                {
                    selectedKey.SetValue("", description);
                }
                if (icon != null)
                {
                    selectedKey.CreateSubKey("DefaultIcon").SetValue("", icon, RegistryValueKind.ExpandString);
                    selectedKey.CreateSubKey(@"Shell\Open").SetValue("icon", icon, RegistryValueKind.ExpandString);
                }
                if (application != null)
                {
                    selectedKey.CreateSubKey(@"Shell\Open\command").SetValue("", "\"" + application + "\"" + " \"%1\"", RegistryValueKind.ExpandString);
                }
            }
            selectedKey.Flush();
            selectedKey.Close();
        }

        public static void SelfCreateAssociation(string extension, KeyHiveSmall hive = KeyHiveSmall.CurrentUser, string description = "")
        {
            string ProgID = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.FullName;
            string FileLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            CreateAssociation(ProgID, extension, description, FileLocation, FileLocation + ",0", hive);
        }
    }
}
