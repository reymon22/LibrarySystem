using System;
using System.Collections.Generic;
using System.IO;

using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Defragment;

using BookStoreGUI;


namespace DataAccess
{
    
    
    public class DatabaseManager : IDisposable
    {

       
        private static DatabaseManager instance = null;
        
        
        
        private IObjectContainer db;

        private bool dbIsOpen;



        private DatabaseManager()
        {
            DBConfiguration.SetConfiguration();
            dbIsOpen = false;
        }


        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DatabaseManager();
                
                return instance;
            }
        }


        
        public void DefragmentDatabase()
        {
            bool defragmentError = false;
            
            try
            {
                CloseDatabase();

                DefragmentConfig defragConfig = new DefragmentConfig(
                            BookStoreGUI.Properties.Settings.Default.DatabaseFilePath,
                            BookStoreGUI.Properties.Settings.Default.DatabaseBackupFilePath);
                defragConfig.Db4oConfig(DBConfiguration.Configuration);
                defragConfig.ForceBackupDelete(true);

                Defragment.Defrag(defragConfig);
            }
            catch (Exception ex)
            {
                defragmentError = true;
                throw new DatabaseException("Could not defragment the database.", ex);
            }

            finally
            {
                if (defragmentError == false)
                {
                    try
                    {
                        if (File.Exists(BookStoreGUI.Properties.Settings.Default.DatabaseBackupFilePath) == true)
                            File.Delete(BookStoreGUI.Properties.Settings.Default.DatabaseBackupFilePath);
                    }
                    catch (Exception) { }
                }
            }
        }


       
        public void PerformDataUpdate(params IUpdateAction[] updateActions)
        {
            OpenDatabase();
            
            try
            {
                foreach (IUpdateAction updateAction in updateActions)
                    updateAction.PerformUpdate(db);

                db.Commit();
            }

            catch (Exception ex)
            {
                db.Rollback();

                throw new DatabaseException("Could not commit changes to the database.", ex);
            }
        }


       
        public IList<GenericType> PerformDataQuery<GenericType>(IQueryAction<GenericType> queryAction)
                                            where GenericType : class
        {
            OpenDatabase();
            
            try
            {
                return queryAction.PerformQuery(db);
            }

            catch (Exception ex)
            {
                throw new DatabaseException("Could not query the database.", ex);
            }
        }


        private void OpenDatabase()
        {
            if (dbIsOpen == false)
            {
                try
                {
                    db = Db4oFactory.OpenFile(DBConfiguration.Configuration,
                                              BookStoreGUI.Properties.Settings.Default.DatabaseFilePath);
                    dbIsOpen = true;
                }

                catch (Exception ex)
                {
                    throw new DatabaseException("Could not open the database.", ex);
                }
            }
        }

        private void CloseDatabase()
        {
            if (dbIsOpen == true)
            {
                db.Close();
                db.Dispose();

                dbIsOpen = false;
            }
        }


        public void Dispose()
        {
            CloseDatabase();
            instance = null;

            GC.SuppressFinalize(this);
        }

        ~DatabaseManager()
        {
            CloseDatabase();
            instance = null;
        }

    }

}
