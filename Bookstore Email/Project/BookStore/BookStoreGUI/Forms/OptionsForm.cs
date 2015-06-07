using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using RegistryAccess;


namespace BookStoreGUI
{
    
    /// <summary>
    /// Form for selecting the database and temporary application
    /// folders, respectively.
    /// </summary>
    public partial class OptionsForm : Form
    {

        /// <summary>
        /// The path to the folder containing the database.
        /// </summary>
        private string databaseFolderPath;

        /// <summary>
        /// The application temporary folder.
        /// </summary>
        private string tempFolderPath;
        
        
        /// <summary>
        /// OptionsForm constructor.
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
        }


        private void OptionsForm_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        
        private void Options_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormClosing += new FormClosingEventHandler(OptionsForm_FormClosing);
        }


        private void btSelectDatabaseFolder_Click(object sender, EventArgs e)
        {
            string message = String.Format("{0}{1}",
                                "Please note that the database folder must be on a drive ",
                                "with enough free space to store the application data.");

            MessageBox.Show(message,
                            "Database Folder Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = true;
            folderBrowser.Description = "Select the database folder:";

            DialogResult folderDialogResult = folderBrowser.ShowDialog();
            if (folderDialogResult == DialogResult.Cancel)
                return;

            string completePath = folderBrowser.SelectedPath;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(completePath);
                dirInfo.GetDirectories();
            }

            catch (Exception)
            {
                MessageBox.Show("The folder selected cannot be accessed.",
                                "Invalid Database Folder",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }

            databaseFolderPath = completePath;
            tbDatabaseFolder.Text = databaseFolderPath;
        }


        private void btSelectTempFolder_Click(object sender, EventArgs e)
        {
            string message = String.Format("{0}{1}{2}{3}{4}",
                                "Please note that the temporary folder must not contain ",
                                "any sensitive data, since its content will be deleted ",
                                "at each application exit.\r\n",
                                "Also, keep in mind that the temporary folder must be on ",
                                "a drive with enough free space to store the temporary data.");

            MessageBox.Show(message,
                            "Temporary Folder Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = true;
            folderBrowser.Description = "Select the temporary folder:";

            DialogResult folderDialogResult = folderBrowser.ShowDialog();
            if (folderDialogResult == DialogResult.Cancel)
                return;

            string completePath = folderBrowser.SelectedPath;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(completePath);
                dirInfo.GetDirectories();
            }

            catch (Exception)
            {
                MessageBox.Show("The folder selected cannot be accessed.",
                                "Invalid Temporary Folder",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }

            tempFolderPath = completePath;
            tbTempFolder.Text = tempFolderPath;
        }


        private void btConfirmSelection_Click(object sender, EventArgs e)
        {
            if ((databaseFolderPath == null) || (tempFolderPath == null))
            {
                MessageBox.Show("Please select the database and temporary folders, respectively.",
                                "Folders Selection Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            if (tempFolderPath.EndsWith(Path.DirectorySeparatorChar.ToString()) == true)
            {
                MessageBox.Show("The temporary folder must not reside on the root of a drive.",
                                "Folders Selection Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            if (databaseFolderPath == tempFolderPath)
            {
                MessageBox.Show("The database folder and temporary folder must be different.",
                                "Folders Selection Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            RegistryHandler.CommitSettingsToRegistry(databaseFolderPath, tempFolderPath);
            this.FormClosing -= OptionsForm_FormClosing;
            this.Close();
        }

    }
}
