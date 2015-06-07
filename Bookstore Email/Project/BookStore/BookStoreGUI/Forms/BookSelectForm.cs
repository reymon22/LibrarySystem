using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BookEntities;


namespace BookStoreGUI
{

    /// <summary>
    /// Form for defining the selection pertaining to query categories.
    /// </summary>
    partial class BookSelectForm : Form
    {

        /// <summary>
        /// The selected item type.
        /// </summary>
        private Type selectedItemType;

        /// <summary>
        /// Business logic command pattern instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// The currently selected book.
        /// </summary>
        private Book book;

        /// <summary>
        /// The list of the selected items in the list box, if the select type in Multi.
        /// </summary>
        private List<object> selectedItems;


        /// <summary>
        /// BookSelectForm constructor.
        /// </summary>
        /// <param name="selectedItemType">The selected item string</param>
        /// <param name="booksManager">Business logic command pattern instance</param>
        /// <param name="book">The meta-data corresponding to the currently selected book</param>
        public BookSelectForm(Type selectedItemType, BooksManager booksManager, Book book)
        {
            this.selectedItemType = selectedItemType;

            this.booksManager = booksManager;
            this.book = book;

            this.selectedItems = new List<object>();

            InitializeComponent();
        }


        private void BookSelectForm_FormClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }


        private void BookSelectForm_Load(object sender, EventArgs e)
        {
            switch (selectedItemType.Name)
            {
                case "PublishingHouse":
                    this.Text = "Publishing House";
                    break;
                case "YearOfPublishing":
                    this.Text = "Year of Publishing";
                    break;
                default:
                    this.Text = selectedItemType.Name;
                    break;
            }

            this.ControlBox = false;
            this.FormClosing += new FormClosingEventHandler(BookSelectForm_FormClosing);

            InitItemsList();
            InitItemsSelection();
        }


        /// <summary>
        /// Initializes the items of the listbox.
        /// </summary>
        private void InitItemsList()
        {
            lbItems.Items.Clear();

            if (selectedItemType == typeof(Author))
                foreach (Author currentAuthor in booksManager.BooksRepository.Authors)
                    lbItems.Items.Add(currentAuthor);

            else if (selectedItemType == typeof(Tag))
                foreach (Tag currentTag in booksManager.BooksRepository.Tags)
                    lbItems.Items.Add(currentTag);

            else if (selectedItemType == typeof(PublishingHouse))
                foreach (PublishingHouse currentPublishingHouse in
                                                        booksManager.BooksRepository.PublishingHouses)
                    lbItems.Items.Add(currentPublishingHouse);

            else if (selectedItemType == typeof(YearOfPublishing))
                foreach (YearOfPublishing currentYearOfPublishing in
                                                        booksManager.BooksRepository.YearsOfPublishing)
                    lbItems.Items.Add(currentYearOfPublishing);
        }


        private void InitItemsSelection()
        {
            if ((selectedItemType == typeof(Author)) && (book.Authors != null))
            {
                foreach (Author bookAuthor in book.Authors)
                    lbItems.SelectedItems.Add(bookAuthor);
            }

            else if ((selectedItemType == typeof(Tag)) && (book.Tags != null))
            {
                foreach (Tag bookTag in book.Tags)
                    lbItems.SelectedItems.Add(bookTag);
            }

            else if (selectedItemType == typeof(PublishingHouse))
            {
                if (book.PublishingHouse != null)
                    lbItems.SelectedItem = book.PublishingHouse;
            }

            else if (selectedItemType == typeof(YearOfPublishing))
            {
                if (book.YearOfPublishing != null)
                    lbItems.SelectedItem = book.YearOfPublishing;
            }
        }


        /// <summary>
        /// Saves the list of selected items.
        /// </summary>
        private void SaveSelectedItems()
        {
            selectedItems = new List<object>();

            foreach (object currentObject in lbItems.SelectedItems)
                selectedItems.Add(currentObject);
        }

        /// <summary>
        /// Restores the selected items in the list box.
        /// </summary>
        private void RestoreSelectedItems()
        {
            foreach (object currentItem in selectedItems)
                lbItems.SelectedItems.Add(currentItem);
        }


        private void btAddNew_Click(object sender, EventArgs e)
        {
            SaveSelectedItems();

            new AddNewItemForm(booksManager, selectedItemType).ShowDialog();

            InitItemsList();
            RestoreSelectedItems();
        }


        private void btRemoveSelected_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove the selected item(s)?",
                                                      "Confirm Item(s) Removal",
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (object currentObject in lbItems.SelectedItems)
                    {
                        if (selectedItemType == typeof(Author))
                            booksManager.BooksRepository.RemoveAuthor((Author)currentObject);

                        else if (selectedItemType == typeof(Tag))
                            booksManager.BooksRepository.RemoveTag((Tag)currentObject);

                        else if (selectedItemType == typeof(PublishingHouse))
                            booksManager.BooksRepository.RemovePublishingHouse((PublishingHouse)currentObject);

                        else if (selectedItemType == typeof(YearOfPublishing))
                            booksManager.BooksRepository.RemoveYearOfPublishing((YearOfPublishing)currentObject);
                    }

                    InitItemsList();
                }
            }
        }


        private void btRenameSelected_Click(object sender, EventArgs e)
        {
            if (lbItems.SelectedItems.Count > 0)
            {
                if (lbItems.SelectedItems.Count > 1)
                    MessageBox.Show("You must select only one item to rename.", "Item Rename Restriction",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else if (lbItems.SelectedItems.Count == 1)
                {
                    SaveSelectedItems();

                    if (selectedItemType == typeof(Author))
                        new RenameItemForm(booksManager, (Author)lbItems.SelectedItems[0]).ShowDialog();

                    else if (selectedItemType == typeof(Tag))
                        new RenameItemForm(booksManager, (Tag)lbItems.SelectedItems[0]).ShowDialog();

                    else if (selectedItemType == typeof(PublishingHouse))
                        new RenameItemForm(booksManager, (PublishingHouse)lbItems.SelectedItems[0]).ShowDialog();

                    else if (selectedItemType == typeof(YearOfPublishing))
                        new RenameItemForm(booksManager, (YearOfPublishing)lbItems.SelectedItems[0]).ShowDialog();

                    InitItemsList();
                    RestoreSelectedItems();
                }
            }
        }


        private void btConfirmSelection_Click(object sender, EventArgs e)
        {
            if (selectedItemType == typeof(PublishingHouse))
            {
                if (selectedItems.Count > 0)
                    booksManager.BooksRepository.SetBookPublishingHouse(book, (PublishingHouse)selectedItems[0]);
                else
                    booksManager.BooksRepository.SetBookPublishingHouse(book, null);
            }

            else if (selectedItemType == typeof(YearOfPublishing))
            {
                if (selectedItems.Count > 0)
                    booksManager.BooksRepository.SetBookYearOfPublishing(book, (YearOfPublishing)selectedItems[0]);
                else
                    booksManager.BooksRepository.SetBookYearOfPublishing(book, null);
            }

            else
            {
                if (selectedItemType == typeof(Author))
                {
                    List<Author> authorsList = new List<Author>();

                    foreach (object currentItem in lbItems.SelectedItems)
                        authorsList.Add((Author)currentItem);

                    booksManager.BooksRepository.SetBookAuthors(book, authorsList);
                }

                else if (selectedItemType == typeof(Tag))
                {
                    List<Tag> tagsList = new List<Tag>();

                    foreach (object currentItem in lbItems.SelectedItems)
                        tagsList.Add((Tag)currentItem);

                    booksManager.BooksRepository.SetBookTags(book, tagsList);
                }
            }

            this.FormClosing -= BookSelectForm_FormClosing;
            this.Close();
        }


        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((selectedItemType == typeof(PublishingHouse)) || (selectedItemType == typeof(YearOfPublishing)))
            {
                if ((selectedItems.Count == 1) && (lbItems.Items.Contains(selectedItems[0])))
                    lbItems.SelectedItems.Remove(selectedItems[0]);
            }
            
            selectedItems = new List<object>();

            foreach (object currentItem in lbItems.SelectedItems)
                selectedItems.Add(currentItem);
        }

    }

}
