using Microsoft.Win32;
using System.Windows.Forms;

namespace Proxler2
{
    

        public static class FileAssociationHelper
        {
            public static readonly string DefaultRegistryKeyValueName = string.Empty;

            public static void AssociateFileExtension(string fileExtension)
            {
            try
            {
                string actualFileExtension = (fileExtension[0] == '.' ? fileExtension : '.' + fileExtension);
                string friendlyName = actualFileExtension.TrimStart(new char[] { '.' }) + "file";


                RegistryKey rkFileExtension = Registry.ClassesRoot.CreateSubKey(actualFileExtension);
                rkFileExtension.SetValue(DefaultRegistryKeyValueName, friendlyName, RegistryValueKind.String);

                RegistryKey rkShellOpenCommand = Registry.ClassesRoot.CreateSubKey(friendlyName + @"\shell\open\command");
                rkShellOpenCommand.SetValue(DefaultRegistryKeyValueName, Application.ExecutablePath + @" ""%l"" ", RegistryValueKind.String);

                RegistryKey rkDefaultIcon = Registry.ClassesRoot.CreateSubKey(friendlyName + @"\DefaultIcon");
                rkDefaultIcon.SetValue(DefaultRegistryKeyValueName, Application.StartupPath + @"\App.ico", RegistryValueKind.String);
            }
            catch
            {

            }
            }
        }
    
}
