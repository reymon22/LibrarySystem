using Microsoft.Win32;
using System;


namespace RegistryAccess
{

    
    public static class RegistryHandler
    {

        
        private const string RegistryAppKey = "BookStore";

        private const string MainSubKey = "Software";
        private const string DbFolderPathString = "Database folder path";
        private const string TempFolderPathString = "Temp folder path";


       
        public static void CommitSettingsToRegistry(string dbFolderPath, string tempFolderPath)
        {
            try
            {
                RegistryKey mainKey = Registry.CurrentUser.OpenSubKey(MainSubKey, true);
                RegistryKey optionsKey;

                optionsKey = mainKey.OpenSubKey(RegistryAppKey, true);

                if (optionsKey == null)
                {
                    mainKey.CreateSubKey(RegistryAppKey);
                    optionsKey = mainKey.OpenSubKey(RegistryAppKey, true);
                }

                optionsKey.SetValue(DbFolderPathString, dbFolderPath, RegistryValueKind.String);
                optionsKey.SetValue(TempFolderPathString, tempFolderPath, RegistryValueKind.String);

                optionsKey.Close();
                mainKey.Close();
            }

            catch (Exception ex)
            {
                throw new RegistryAccessException("Could not commit configuration data to the registry.", ex);
            }
        }


       
        public static bool RegistryConfigDataExists()
        {
            bool dataExists = false;

            try
            {
                RegistryKey mainKey = Registry.CurrentUser.OpenSubKey(MainSubKey, true);
                RegistryKey optionsKey;

                optionsKey = mainKey.OpenSubKey(RegistryAppKey, true);

                if (optionsKey == null)
                {
                    mainKey.Close();
                    return dataExists;
                }

                string dbFolderPath = (string)optionsKey.GetValue(DbFolderPathString, String.Empty);
                string tempFolderPath = (string)optionsKey.GetValue(TempFolderPathString, String.Empty);

                optionsKey.Close();
                mainKey.Close();

                if ((dbFolderPath != String.Empty) && (tempFolderPath != String.Empty))
                    dataExists = true;

                return dataExists;
            }

            catch (Exception)
            {
                return dataExists;
            }
        }


    
        public static void ExtractRegistrySettings(out string dbFolderPath, out string tempFolderPath)
        {
            try
            {
                RegistryKey mainKey = Registry.CurrentUser.OpenSubKey(MainSubKey, true);
                RegistryKey optionsKey;

                optionsKey = mainKey.OpenSubKey(RegistryAppKey);

                if (optionsKey == null)
                {
                    mainKey.Close();

                    throw new RegistryAccessException("Could not commit configuration data to the registry.",
                                                      null);
                }

                dbFolderPath = (string)optionsKey.GetValue(DbFolderPathString, String.Empty);
                tempFolderPath = (string)optionsKey.GetValue(TempFolderPathString, String.Empty);

                optionsKey.Close();
                mainKey.Close();

                if ((dbFolderPath == String.Empty) || (tempFolderPath == String.Empty))
                    throw new RegistryAccessException("Could not commit configuration data to the registry.",
                                                      null);
            }

            catch (Exception ex)
            {
                throw new RegistryAccessException("Could not commit configuration data to the registry.", ex);
            }
        }


        
        public static void DeleteRegistrySettings()
        {
            try
            {
                RegistryKey mainKey = Registry.CurrentUser.OpenSubKey(MainSubKey, true);

                mainKey.DeleteSubKey(RegistryAppKey);

                mainKey.Close();
            }

            catch (Exception)
            {
            }
        }

    }

}
