using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BookEntities;


namespace BookStoreGUI
{
    
    partial class BookDetails : UserControl
    {

        /// <summary>
        /// Business logic command pattern instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// Object defining operations to be performed on a list of books.
        /// </summary>
        private BooksListOperations booksListOperations;

        /// <summary>
        /// The currently selected book.
        /// </summary>
        private Book book;


        /// <summary>
        /// BookDetails constructor.
        /// </summary>
        /// <param name="booksManager">Business logic command pattern instance</param>
        /// <param name="booksListOperations">Object defining operations to be performed on a list of books</param>
        public BookDetails(BooksManager booksManager, BooksListOperations booksListOperations)
        {
            this.booksManager = booksManager;
            this.booksListOperations = booksListOperations;
            
            InitializeComponent();
        }


        /// <summary>
        /// Sets the book exposed by the user control.
        /// </summary>
        /// <param name="currentBook">The book to be set.</param>
        public void SetCurrentBookDetails(Book currentBook)
        {
            this.book = currentBook;

            RefreshContent();
        }


        /// <summary>
        /// Clears the textboxes of the user control.
        /// </summary>
        public void ClearDataAndFields()
        {
            tbTitle.Text = string.Empty;
            tbAuthors.Text = string.Empty;
            tbTags.Text = string.Empty;
            tbPublishingHouse.Text = string.Empty;
            tbYearOfPublishing.Text = string.Empty;
        }


        /// <summary>
        /// Refreshes the content presented by the user control.
        /// </summary>
        private void RefreshContent()
        {
            ClearDataAndFields();

            if (book != null)
            {
                tbTitle.Text = book.Title;

                tbAuthors.Text = string.Empty;
                if (book.Authors != null)
                    foreach (Author currentAuthor in book.Authors)
                    {
                        if (tbAuthors.Text != string.Empty)
                            tbAuthors.Text += ", ";
                        tbAuthors.Text += currentAuthor.ToString();
                    }

                tbTags.Text = string.Empty;
                if (book.Tags != null)
                    foreach (Tag currentTag in book.Tags)
                    {
                        if (tbTags.Text != string.Empty)
                            tbTags.Text += ", ";
                        tbTags.Text += currentTag.ToString();
                    }

                if (book.PublishingHouse != null)
                    tbPublishingHouse.Text = book.PublishingHouse.ToString();
                else
                    tbPublishingHouse.Text = String.Empty;

                if (book.YearOfPublishing != null)
                    tbYearOfPublishing.Text = book.YearOfPublishing.ToString();
                else
                    tbYearOfPublishing.Text = String.Empty;
            }
        }


        private void btSetBookTitle_Click(object sender, EventArgs e)
        {
            if (book != null)
            {
                tbTitle.Text = tbTitle.Text.Trim();

                if (tbTitle.Text != book.Title)
                {
                    if (tbTitle.Text != string.Empty)
                    {
                        book.Title = tbTitle.Text;
                        booksListOperations.ChangeBookTitle();
                    }

                    else
                        tbTitle.Text = book.Title;
                }
            }
        }


        private void btSelectAuthors_Click(object sender, EventArgs e)
        {
            if (book != null)
            {
                new BookSelectForm(typeof(Author), booksManager, book).ShowDialog();

                RefreshContent();
            }
        }


        private void btSelectTags_Click(object sender, EventArgs e)
        {
            if (book != null)
            {
                new BookSelectForm(typeof(Tag), booksManager, book).ShowDialog();

                RefreshContent();
            }
        }


        private void btSelectPublishingHouse_Click(object sender, EventArgs e)
        {
            if (book != null)
            {
                new BookSelectForm(typeof(PublishingHouse), booksManager, book).ShowDialog();

                RefreshContent();
            }
        }


        private void btSelectYearOfPublishing_Click(object sender, EventArgs e)
        {
            if (book != null)
            {
                new BookSelectForm(typeof(YearOfPublishing), booksManager, book).ShowDialog();

                RefreshContent();
            }
        }


        /// <summary>
        /// Displays the content of the selected book.
        /// </summary>
        private void DisplayBook()
        {
            try
            {
                book.DisplayBookContent(Properties.Settings.Default.TempFolderPath);
            }

            catch (BookEntitiesException)
            {
                string errorMessage = String.Format("{0}{1}{2}",
                    "Could not display the selected book.\r\n",
                    "Probably no application registered with the book ",
                    "file type, temporary folder inaccessible or disc full.");

                MessageBox.Show(errorMessage,
                                "Book Display Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btViewBook_Click(object sender, EventArgs e)
        {
            if (book != null)
                new BackgroundTask("Displaying book ... ", DisplayBook);
        }


        /// <summary>
        /// Deletes the book content and its corresponding book meta-data
        /// from the system.
        /// </summary>
        private void DeleteBook()
        {
            try
            {
                booksManager.RemoveBook(book);
            }

            catch (BookEntitiesException)
            {
                MessageBox.Show("Could not delete the selected book.",
                                "Book Delete Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btDeleteBook_Click(object sender, EventArgs e)
        {
            if (book != null)
            {
                string deleteConfirmMessage;

                if (book.Authors.Count > 0)
                    deleteConfirmMessage = String.Format("{0}{1}{2}{3}{4}",
                                                "Are you sure you want to delete the book \"",
                                                book.Title,
                                                "\", written by \"",
                                                book.Authors[0],
                                                "\" from the database?");
                else
                    deleteConfirmMessage = String.Format("{0}{1}{2}",
                                                "Are you sure you want to delete the book \"",
                                                book.Title,
                                                "\" from the database?");


                DialogResult result = MessageBox.Show(
                    deleteConfirmMessage,
                    "Confirm Book Deletion",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                    );


                if (result == DialogResult.Yes)
                {
                    new BackgroundTask("Deleting book ... ", DeleteBook);

                    booksListOperations.DeleteBook();

                    ClearDataAndFields();
                    book = null;
                }
            }
        }
        
    }
}
