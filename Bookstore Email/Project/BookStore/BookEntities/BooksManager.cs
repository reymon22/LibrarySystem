using System;
using System.Collections.Generic;

using DataAccess;
using DiscAccess;


namespace BookEntities
{

    /// <summary>
    /// Singleton manager class for any book-related business logic.
    /// </summary>
    public class BooksManager : IDisposable
    {

        private static BooksManager instance = null;

        /// <summary>
        /// The books repository.
        /// </summary>
        private BooksData booksData;


        /// <summary>
        /// Defragments the database file.
        /// </summary>
        public void DefragmentDatabase()
        {
            booksData.UpdateDatabase();

            try
            {
                DatabaseManager.Instance.DefragmentDatabase();

                try
                {
                    if (System.IO.File.Exists(BookStoreGUI.Properties.Settings.Default.DatabaseBackupFileName) == true)
                        System.IO.File.Delete(BookStoreGUI.Properties.Settings.Default.DatabaseBackupFileName);
                }

                catch (Exception)
                {
                }
            }

            catch (DiscAccessException ex)
            {
                throw new BookEntitiesException("Could not defragment the database.", ex);
            }

            finally
            {
                GetBooksData();
            }
        }


        /// <summary>
        /// Gets the BooksCommand instance.
        /// </summary>
        public static BooksManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new BooksManager();

                return instance;
            }
        }

        private BooksManager()
        {
            try
            {
                if (System.IO.Directory.Exists(BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath) == false)
                    System.IO.Directory.CreateDirectory(BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath);

                if (System.IO.Directory.Exists(BookStoreGUI.Properties.Settings.Default.TempFolderPath) == false)
                    System.IO.Directory.CreateDirectory(BookStoreGUI.Properties.Settings.Default.TempFolderPath);
            }

            catch (Exception ex)
            {
                throw new BookEntitiesException("Could not create folder structure", ex);
            }


            if (BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) == false)
                BookStoreGUI.Properties.Settings.Default.DatabaseFilePath =
                    String.Format("{0}{1}", BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath,
                                            System.IO.Path.DirectorySeparatorChar);
            else
                BookStoreGUI.Properties.Settings.Default.DatabaseFilePath =
                                            BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath;

            BookStoreGUI.Properties.Settings.Default.DatabaseFilePath = String.Format("{0}{1}",
                                            BookStoreGUI.Properties.Settings.Default.DatabaseFilePath,
                                            BookStoreGUI.Properties.Settings.Default.DatabaseFileName);


            if (BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) == false)
                BookStoreGUI.Properties.Settings.Default.DatabaseBackupFilePath = 
                    String.Format("{0}{1}", BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath,
                                            System.IO.Path.DirectorySeparatorChar);
            else
                BookStoreGUI.Properties.Settings.Default.DatabaseBackupFilePath = 
                                            BookStoreGUI.Properties.Settings.Default.DatabaseFolderPath;

            BookStoreGUI.Properties.Settings.Default.DatabaseBackupFilePath = String.Format("{0}{1}",
                                            BookStoreGUI.Properties.Settings.Default.DatabaseBackupFilePath,
                                            BookStoreGUI.Properties.Settings.Default.DatabaseBackupFileName);


            GetBooksData();
        }


        private void CleanUpBooksData()
        {
            if (booksData != null)
            {
                try
                {
                    booksData.UpdateDatabase();
                }
                catch (BookEntitiesException) { }
            }

            DatabaseManager.Instance.Dispose();
            CleanTempFolder();
        }


        /// <summary>
        /// IDisposable-compliant dispose method.
        /// </summary>
        public void Dispose()
        {
            CleanUpBooksData();
            instance = null;

            GC.SuppressFinalize(this);
        }

        ~BooksManager()
        {
            CleanUpBooksData();
            instance = null;
        }


        /// <summary>
        /// Cleans the content of the temporary folder of the application.
        /// </summary>
        private void CleanTempFolder()
        {
            try
            {
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(
                                                    BookStoreGUI.Properties.Settings.Default.TempFolderPath);

                foreach (System.IO.DirectoryInfo subDirInfo in dirInfo.GetDirectories())
                {
                    IDiscEntry currentDiscEntry = new Folder(
                                                BookStoreGUI.Properties.Settings.Default.TempFolderPath,
                                                subDirInfo.Name);

                    currentDiscEntry.DeleteStructureFromDisc();
                }
            }
            catch (Exception) { }
        }


        /// <summary>
        /// Retrieves the content of the book-related business logic object
        /// from the database.
        /// </summary>
        private void GetBooksData()
        {
            try
            {
                IList<BooksData> queryAnswer =
                    DatabaseManager.Instance.PerformDataQuery<BooksData>(
                                        new QueryByExampleAction<BooksData>(new BooksData(), 1));

                if (queryAnswer.Count == 0)
                    booksData = new BooksData();

                else
                {
                    if (queryAnswer.Count == 1)
                        booksData = queryAnswer[0];

                    else
                        throw new DatabaseException(@"There is more than one books repository 
                                                    inside the database.", null);
                }
            }

            catch (DatabaseException ex)
            {
                throw new BookEntitiesException("Invalid database file.", ex);
            }
        }


        public BooksData BooksRepository
        {
            get { return booksData; }
        }


        /// <summary>
        /// Adds a new file-based book to the database.
        /// </summary>
        /// <param name="rootPath">The root path to the book file</param>
        /// <param name="path">The path to the book file, starting from the root path</param>
        public void AddNewFileBasedBook(string rootPath, string path)
        {
            try
            {
                IDiscEntry currentEntry = new File(rootPath, path);

                Book newBook = new Book(currentEntry, path, false, currentEntry.Name);
                DatabaseManager.Instance.PerformDataUpdate(new UpdateStoreAction(newBook));
                newBook.ReadStructureFromDisc();

                booksData.AddNewBook(newBook);
            }

            catch (Exception ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Adds a new folder-based book to the database.
        /// </summary>
        /// <param name="rootPath">The root path to the book folder</param>
        /// <param name="path">The path to the book folder, starting from the root path</param>
        /// <param name="entryPointPath">The file that represents the entry point in the book folder</param>
        public void AddNewFolderBasedBook(string rootPath, string path, string entryPointPath)
        {
            try
            {
                IDiscEntry currentEntry = new Folder(rootPath, path);
                
                Book newBook = new Book(currentEntry, entryPointPath, true, currentEntry.Name);
                DatabaseManager.Instance.PerformDataUpdate(new UpdateStoreAction(newBook));
                newBook.ReadStructureFromDisc();

                booksData.AddNewBook(newBook);
            }

            catch (Exception ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Adds a set of new file-based books to the database.
        /// </summary>
        /// <param name="rootPath">The root path to the folder containing the file-based books</param>
        /// <param name="path">The path to the folder containg the file-based books,
        /// starting from the root path</param>
        public void BulkAddNewFilesBasedBooks(string rootPath, string path)
        {
            bool allBooksReadable = true;
            List<IDiscEntry> bulkLoadFilesList;

            try
            {
                bulkLoadFilesList = new List<IDiscEntry>();
                IDiscEntry bulkLoadEntry = new Folder(rootPath, path);

                bulkLoadEntry.BulkLoadSingleFiles(bulkLoadFilesList);
            }

            catch (Exception ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }

            foreach (IDiscEntry newFile in bulkLoadFilesList)
            {
                try
                {
                    Book newBook = new Book(newFile, newFile.Path, false, newFile.Name);
                    DatabaseManager.Instance.PerformDataUpdate(new UpdateStoreAction(newBook));
                    newBook.ReadStructureFromDisc();

                    booksData.AddNewBook(newBook);
                }

                catch (Exception)
                {
                    allBooksReadable = false;
                }
            }

            if (allBooksReadable == false)
                throw new BookEntitiesException("Some of the books could not be read from the disc.", null);
        }


        /// <summary>
        /// Removes a book from the databas.
        /// </summary>
        /// <param name="bookToRemove">The book to be remove</param>
        public void RemoveBook(Book bookToRemove)
        {
            booksData.RemoveBook(bookToRemove);
        }

    }

}
