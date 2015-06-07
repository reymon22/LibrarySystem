using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using BookEntities;


namespace BookStoreGUI
{

    public partial class MainForm : Form
    {

        /// <summary>
        /// Extracts the path information for a book folder or file on the disc.
        /// </summary>
        /// <param name="completePath">The complete path to the book on the disc</param>
        /// <param name="rootPath">The root path to the book on the disc</param>
        /// <param name="path">The path to the book on the disc, starting from the
        /// root path</param>
        private void ExtractPathInfo(string completePath, out string rootPath, out string path)
        {
            if (completePath.EndsWith(Path.DirectorySeparatorChar.ToString()) == true)
            {
                rootPath = completePath;
                path = string.Empty;
            }

            else
            {
                int splitPosition = completePath.LastIndexOf(Path.DirectorySeparatorChar);

                rootPath = completePath.Substring(0, splitPosition + 1);
                path = completePath.Substring(splitPosition + 1);
            }
        }


        /// <summary>
        /// Adds a file-based book to the database.
        /// </summary>
        private void AddFileBasedBook()
        {
            try
            {
                booksManager.AddNewFileBasedBook(rootPath, path);
            }

            catch (BookEntitiesException)
            {
                string message = String.Format("{0}{1}",
                    "Could not add the selected book to the database.\r\n\r\n",
                    "Either the disc is full or the file cannot be read.");

                MessageBox.Show(message, "Book Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAddFileBasedBook_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckPathExists = true;
            fileDialog.CheckFileExists = true;
            fileDialog.Filter = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                                              "All files (*.*)|*.*",
                                              "Compiled HTML files (*.chm)|*.chm",
                                              "HTML files (*.htm, *.html)|*.htm;*.html",
                                              "Microsoft PowerPoint files (*.ppt, *.pptx, *.pps)|*.ppt;*.pptx;*.pps",
                                              "Microsoft Word files (*.doc, *.docx)|*.doc;*.docx",
                                              "Open Document Format files (*.odf)|*.odf",
                                              "Rich Text Format files (*.rtf)|*.rtf",
                                              "Portable Document Format files (*.pdf)|*.pdf",
                                              "Text files (*.txt)|*.txt");
            fileDialog.InitialDirectory = Properties.Settings.Default.BooksFolder;
            fileDialog.RestoreDirectory = true;
            fileDialog.SupportMultiDottedExtensions = true;
            fileDialog.Title = "Select the book file:";

            DialogResult fileDialogResult = fileDialog.ShowDialog();
            if (fileDialogResult == DialogResult.Cancel)
                return;

            ExtractPathInfo(fileDialog.FileName, out rootPath, out path);
            Properties.Settings.Default.BooksFolder = rootPath;

            new BackgroundTask("Adding the book to the database ... ",
                               AddFileBasedBook);

            PopulateViewTab();
        }


        /// <summary>
        /// Adds a folder-based book to the database.
        /// </summary>
        private void AddFolderBasedBook()
        {
            try
            {
                booksManager.AddNewFolderBasedBook(rootPath, path, entryPoint);
            }

            catch (BookEntitiesException)
            {
                string message = String.Format("{0}{1}",
                    "Could not add the selected book to the database.\r\n\r\n",
                    "Either the disc is full or the file cannot be read.");

                MessageBox.Show(message, "Book Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAddFolderBasedBook_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = false;
            folderBrowser.SelectedPath = Properties.Settings.Default.BooksFolder;
            folderBrowser.Description = "Select the folder which contains the book:";

            DialogResult folderDialogResult = folderBrowser.ShowDialog();
            if (folderDialogResult == DialogResult.Cancel)
                return;

            Properties.Settings.Default.BooksFolder = folderBrowser.SelectedPath;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Properties.Settings.Default.BooksFolder);
                dirInfo.GetDirectories();
            }

            catch (Exception)
            {
                MessageBox.Show("The folder selected cannot be accessed.",
                                "Invalid Book Folder",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                
                return;
            }

            ExtractPathInfo(Properties.Settings.Default.BooksFolder, out rootPath, out path);

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckPathExists = true;
            fileDialog.CheckFileExists = true;
            fileDialog.Filter = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}",
                                              "All files (*.*)|*.*",
                                              "Compiled HTML files (*.chm)|*.chm",
                                              "HTML files (*.htm, *.html)|*.htm;*.html",
                                              "Microsoft PowerPoint files (*.ppt, *.pptx, *.pps)|*.ppt;*.pptx;*.pps",
                                              "Microsoft Word files (*.doc, *.docx)|*.doc;*.docx",
                                              "Open Document Format files (*.odf)|*.odf",
                                              "Rich Text Format files (*.rtf)|*.rtf",
                                              "Portable Document Format files (*.pdf)|*.pdf",
                                              "Text files (*.txt)|*.txt");
            fileDialog.InitialDirectory = Properties.Settings.Default.BooksFolder;
            fileDialog.RestoreDirectory = true;
            fileDialog.SupportMultiDottedExtensions = true;
            fileDialog.Title = "Select the file entry-point to the folder";

            DialogResult fileDialogResult = fileDialog.ShowDialog();
            if (fileDialogResult == DialogResult.Cancel)
                return;

            entryPoint = fileDialog.FileName;
            int rootPathStartIndex = entryPoint.LastIndexOf(rootPath);
            int pathStartIndex = entryPoint.LastIndexOf(path);
            if ( (rootPathStartIndex < 0) || (pathStartIndex < 0) )
            {
                MessageBox.Show("The book entry point is not valid.",
                                "Invalid Book Entry Point",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            entryPoint = entryPoint.Substring(rootPathStartIndex + rootPath.Length);

            new BackgroundTask("Adding the book to the database ... ", AddFolderBasedBook);

            PopulateViewTab();
        }


        /// <summary>
        /// Bulk-adds all the file-based from a given folder to the database.
        /// </summary>
        private void BulkAddFileBasedBooks()
        {
            try
            {
                booksManager.BulkAddNewFilesBasedBooks(rootPath, path);
            }

            catch (Exception)
            {
                string message = String.Format("{0}{1}",
                    "Could not add some of the the selected book to the database.\r\n\r\n",
                    "Either the disc is full or some of the files cannot be read.");

                MessageBox.Show(message, "Book Bulk Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btBulkAddFileBasedBooks_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = false;
            folderBrowser.SelectedPath = Properties.Settings.Default.BooksFolder;
            folderBrowser.Description = "Select the folder which contains the books:";

            DialogResult folderDialogResult = folderBrowser.ShowDialog();
            if (folderDialogResult == DialogResult.Cancel)
                return;

            Properties.Settings.Default.BooksFolder = folderBrowser.SelectedPath;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Properties.Settings.Default.BooksFolder);
                dirInfo.GetDirectories();
            }

            catch (Exception)
            {
                MessageBox.Show("The folder selected cannot be accessed.",
                                "Invalid Book Folder",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }

            ExtractPathInfo(Properties.Settings.Default.BooksFolder, out rootPath, out path);

            new BackgroundTask("Bulk adding the books to the database ... ", BulkAddFileBasedBooks);

            PopulateViewTab();
        }

    }

}
