using Microsoft.Win32;

namespace SRC.Library.Common
{
    public class RegistryHelper
    {
        private RegistryKey baseKey = null;

        private RegistryHelper()
        {
            baseKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\PROD", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.ReadKey);
            //baseKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\DEV", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.ReadKey);
        }

        public string Value(string keyName)
        {
            return baseKey.GetValue(keyName, string.Empty).ToString();
        }

        ~RegistryHelper()
        {
            baseKey.Close();
        }

        private static RegistryHelper registryHelperInstance = null;
        private static readonly object lockthread = new object();

        public static RegistryHelper Get
        {
            get
            {
                lock (lockthread)
                {
                    if (registryHelperInstance == null)
                    {
                        registryHelperInstance = new RegistryHelper();
                    }
                    return registryHelperInstance;
                }
            }
        }
    }
}
