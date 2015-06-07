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
    public partial class AddNewItemForm : Form
    {

        /// <summary>
        /// Business logic command pattern instance.
        /// </summary>
        private BooksManager booksManager;
        
        /// <summary>
        /// The type of book meta data.
        /// </summary>
        private Type bookMetaDataType;
        
        
        /// <summary>
        /// AddNewItemForm constructor.
        /// </summary>
        /// <param name="booksManager">Business logic command pattern instance</param>
        /// <param name="bookMetaDataType">The type of book meta data</param>
        public AddNewItemForm(BooksManager booksManager, Type bookMetaDataType)
        {
            this.booksManager = booksManager;
            this.bookMetaDataType = bookMetaDataType;
            
            InitializeComponent();
        }


        private void AddNewItemForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormClosing += new FormClosingEventHandler(AddNewItemForm_FormClosing);

            switch (bookMetaDataType.Name)
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


        private void AddNewItemForm_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }


        /// <summary>
        /// Closes the form and releasing its resources.
        /// </summary>
        private void CloseAndReleaseResources()
        {
            this.FormClosing -= AddNewItemForm_FormClosing;

            this.Close();
        }


        /// <summary>
        /// Adds a new item to the current book meta-data category.
        /// </summary>
        private void AddItem()
        {
            string newItem = tbNewItem.Text.Trim();

            if (newItem != string.Empty)
            {
                switch (bookMetaDataType.Name)
                {
                    case "Author":
                        booksManager.BooksRepository.AddAuthor(new Author(newItem));
                        break;
                    case "Tag":
                        booksManager.BooksRepository.AddTag(new Tag(newItem));
                        break;
                    case "PublishingHouse":
                        booksManager.BooksRepository.AddPublishingHouse(new PublishingHouse(newItem));
                        break;
                    case "YearOfPublishing":
                        DateTime newYear;
                        if (DateTime.TryParseExact(newItem, "yyyy", CultureInfo.InvariantCulture,
                                                   DateTimeStyles.None, out newYear) == true)
                            booksManager.BooksRepository.AddYearOfPublishing(newYear.Year);
                        break;
                }
            }

            CloseAndReleaseResources();
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void tbNewItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddItem();
        }


        private void btCancel_Click(object sender, EventArgs e)
        {
            CloseAndReleaseResources();
        }

    }

}
