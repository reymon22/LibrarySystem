using Db4objects.Db4o;
using Db4objects.Db4o.Config;


namespace DataAccess
{

  
    static class DBConfiguration
    {

        private static IConfiguration dbConfig;

        public static void SetConfiguration()
        {
            dbConfig = Db4oFactory.NewConfiguration();

            dbConfig.BlockSize(BookStoreGUI.Properties.Settings.Default.CurrentBlockSize);
            dbConfig.DatabaseGrowthSize(BookStoreGUI.Properties.Settings.Default.SizeGrowthInBytes);
            dbConfig.LockDatabaseFile(BookStoreGUI.Properties.Settings.Default.LockDatabaseFile);
            dbConfig.OptimizeNativeQueries(BookStoreGUI.Properties.Settings.Default.OptimizeNativeQueries);
            dbConfig.Unicode(BookStoreGUI.Properties.Settings.Default.Unicode);
            dbConfig.ActivationDepth(BookStoreGUI.Properties.Settings.Default.ActivationDepth);
            dbConfig.UpdateDepth(BookStoreGUI.Properties.Settings.Default.UpdateDepth);

            DBSpecificConfiguration.SetConfiguration();
        }


        public static IConfiguration Configuration
        {
            get { return dbConfig; }
        }


        public static void SetIndexedField(object clazz, string indexedField)
        {
            dbConfig.ObjectClass(clazz).ObjectField(indexedField).Indexed(true);
        }

        public static void SetCascadeOnActivate(object clazz)
        {
            dbConfig.ObjectClass(clazz).CascadeOnActivate(true);
        }

        public static void SetCascadeOnDelete(object clazz)
        {
            dbConfig.ObjectClass(clazz).CascadeOnDelete(true);
        }

        public static void SetCascadeOnUpdate(object clazz)
        {
            dbConfig.ObjectClass(clazz).CascadeOnUpdate(true);
        }

    }

}
