using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using BookEntities;
using RegistryAccess;


namespace BookStoreGUI
{
    
    public partial class MainForm : Form
    {

        private const char Space = ' ';

        /// <summary>
        /// The book query categories count.
        /// </summary>
        private const int QueryCategoriesCount = 4;

        /// <summary>
        /// The database and temporary application folders. 
        /// </summary>
        private string dbFolder, tempFolder;

        /// <summary>
        /// Book-specific folders.
        /// </summary>
        private string rootPath, path, entryPoint;
        
        /// <summary>
        /// Business logic command pattern instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// Details about the currently selected book.
        /// </summary>
        private BookDetails bookDetails;

        /// <summary>
        /// The currently selected book.
        /// </summary>
        private Book currentBook;

        /// <summary>
        /// Books-related delegate objects.
        /// </summary>
        private GetBooks GetBooksMethod;
        private List<Book> soughtBooks;


        /// <summary>
        /// Book query user control objects, each corresponding to a particular query
        /// category.
        /// </summary>
        private BookQueryControl bookQueryAuthors, bookQueryTags, bookQueryPublishingHouse,
                                 bookQueryYearOfPublishing;

        /// <summary>
        /// The list of the book query categories.
        /// </summary>
        private List<BookQueryControl> queryTabs;


        /// <summary>
        /// MainForm constrcutor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Defragments the database.
        /// </summary>
        private void DefragmentDatabase()
        {
            try
            {
                booksManager.DefragmentDatabase();
            }

            catch (BookEntitiesException)
            {
                string errorMessage = String.Format("{0}\r\n{1}",
                        "Could not defragment the database.",
                        "Exiting the application.");

                MessageBox.Show(errorMessage,
                                "Database Defragmentation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                Application.Exit();
            }
        }


        /// <summary>
        /// Reads the application settings from the Windows Registry.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                RegistryHandler.ExtractRegistrySettings(out dbFolder, out tempFolder);

                Properties.Settings.Default.DatabaseFolderPath = dbFolder;
                Properties.Settings.Default.TempFolderPath = tempFolder;
            }

            catch (Exception ex)
            {
                RegistryHandler.DeleteRegistrySettings();
                throw new RegistryAccessException("Could not access the registry settings.", ex);
            }

            try
            {
                booksManager = BooksManager.Instance;
            }

            catch (BookEntitiesException)
            {
                throw;
            }
        }

        private void SetupRegistrySettings()
        {
            try
            {
                if (RegistryHandler.RegistryConfigDataExists() == false)
                    new OptionsForm().ShowDialog();
            }
            catch (Exception ex)
            {
                RegistryHandler.DeleteRegistrySettings();
                throw new RegistryAccessException("Could not access the registry.", ex);
            }
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                SetupRegistrySettings();
                
                new BackgroundTask("Starting BookStore ...", LoadSettings);

                Properties.Settings.Default.BooksFolder =
                            Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                cbQueryType.SelectedIndex = 0;
                queryTabs = new List<BookQueryControl>(QueryCategoriesCount);
                PopulateTabSearch();

                bookDetails = new BookDetails(booksManager, new BooksListOperations(ChangeBookTitle, DeleteBook));
                flpViewBooks.Controls.Add(bookDetails);
                bookDetails.TabIndex = 1;

                tcMain.SelectedTab = tabViewBooks;
                cbViewBooks.SelectedIndex = 0;
                ResetBooksList();
            }
            catch (BookEntitiesException)
            {
                string errorMessage = String.Format("{0}\r\n{1}",
                        "Could not create or read the existing database.",
                        "Exiting the application.");

                MessageBox.Show(errorMessage,
                                "Database Access Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.FormClosing -= MainForm_FormClosing;
                this.Close();
            }
            catch (RegistryAccessException)
            {
                string errorMessage = String.Format("{0}\r\n{1}",
                        "Could not access the registry.",
                        "Exiting the application.");

                MessageBox.Show(errorMessage,
                                "Registry Access Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.FormClosing -= MainForm_FormClosing;
                this.Close();
            }
        }



        /// <summary>
        /// Releases all the book-related resources.
        /// </summary>
        private void DisposeBooks()
        {
            booksManager.Dispose();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new BackgroundTask("Saving data and cleaning up resources ... ", DisposeBooks);
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMain.SelectedTab == tabSearchForBooks)
                RefreshSearchForBooksTab();
        }


        private void miDefragmentDatabase_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show("Are you sure you want to defragment the application's database?",
                                "Application Database Defragmentation",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new BackgroundTask("Defragmenting the database ...",
                                   new BackgroundTask.BackgroundOperation(DefragmentDatabase));

                ResetBooksList();

                MessageBox.Show("Database defragmentation complete.",
                                "Database Defragmentation Status",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }


        private void miResetConfiguration_Click(object sender, EventArgs e)
        {
            DialogResult result =
                MessageBox.Show("Are you sure you want to reset the application's configuration?",
                                "Application Configuration Reset",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RegistryHandler.DeleteRegistrySettings();

                string resetMessage = String.Format("{0}{1}",
                        "You will be able to set the new configuration the ",
                        "next time the application is started.");

                MessageBox.Show(resetMessage,
                                "Application Configuration Reset",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }


        private void miAbout_Click(object sender, EventArgs e)
        {
            string information = String.Format("{0}\r\n{1}\r\n{2} {3}",
                                               "Book Store Application",
                                               ((AssemblyCopyrightAttribute)(Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0])).Copyright,
                                               "Version", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            
            MessageBox.Show(information,
                            "About Book Store",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }

}
