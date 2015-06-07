using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using BookEntities;


namespace BookStoreGUI
{
    
    /// <summary>
    /// Form for adding a new item to a book meta-data category.
    /// </summary>
    public partial class RenameItemForm : Form
    {

        /// <summary>
        /// Business logic command pattern instance.
        /// </summary>
        private BooksManager booksManager;
        
        /// <summary>
        /// The book meta data object to be renamed.
        /// </summary>
        private IBookMetaData bookMetaDataObject;
        
        
        /// <summary>
        /// RenameItemForm constructor.
        /// </summary>
        /// <param name="booksManager">Business logic command pattern instance</param>
        /// <param name="bookMetaDataObject">The book meta data object to be renamed</param>
        public RenameItemForm(BooksManager booksManager, IBookMetaData bookMetaDataObject)
        {
            this.booksManager = booksManager;
            this.bookMetaDataObject = bookMetaDataObject;
            
            InitializeComponent();
        }


        private void RenameItemForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormClosing += new FormClosingEventHandler(RenameItemForm_FormClosing);
            tbItemToRename.Text = bookMetaDataObject.ToString();

            switch (bookMetaDataObject.GetType().Name)
            {
                case "Author":
                    this.Text += " author";
                    break;
                case "Tag":
                    this.Text += " tag";
                    break;
                case "PublishingHouse":
                    this.Text += " publishing house";
                    break;
                case "YearOfPublishing":
                    this.Text += " year of publishing";
                    break;
            }
        }


        private void RenameItemForm_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }


        /// <summary>
        /// Closes the form and releasing its resources.
        /// </summary>
        private void CloseAndReleaseResources()
        {
            this.FormClosing -= RenameItemForm_FormClosing;

            this.Close();
        }


        /// <summary>
        /// Renames a new item to the current book meta-data category.
        /// </summary>
        private void RenameItem()
        {
            string renamedItem = tbItemToRename.Text.Trim();

            if (renamedItem != bookMetaDataObject.ToString())
            {
                if (renamedItem != string.Empty)
                {
                    switch (bookMetaDataObject.GetType().Name)
                    {
                        case "Author":
                            booksManager.BooksRepository.RenameAuthor(((Author)bookMetaDataObject), renamedItem);
                            break;
                        case "Tag":
                            booksManager.BooksRepository.RenameTag(((Tag)bookMetaDataObject), renamedItem);
                            break;
                        case "PublishingHouse":
                            booksManager.BooksRepository.RenamePublishingHouse(
                                                        ((PublishingHouse)bookMetaDataObject), renamedItem);
                            break;
                        case "YearOfPublishing":
                            DateTime renamedYear;
                            if (DateTime.TryParseExact(renamedItem, "yyyy", CultureInfo.InvariantCulture,
                                                       DateTimeStyles.None, out renamedYear) == true)
                                booksManager.BooksRepository.RenameYearOfPublishing(
                                                       ((YearOfPublishing)bookMetaDataObject), renamedYear.Year);
                            break;
                    }
                } 
            }

            CloseAndReleaseResources();
        }

        private void btRenameItem_Click(object sender, EventArgs e)
        {
            RenameItem();
        }


        private void tbItemToRename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RenameItem();
        }


        private void btCancel_Click(object sender, EventArgs e)
        {
            CloseAndReleaseResources();
        }

    }

}
