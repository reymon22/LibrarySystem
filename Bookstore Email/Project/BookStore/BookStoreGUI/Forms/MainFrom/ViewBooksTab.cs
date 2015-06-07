using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BookEntities;


namespace BookStoreGUI
{

    public partial class MainForm : Form
    {

        /// <summary>
        /// Returns the books that have been queried by a given criteria.
        /// </summary>
        /// <returns></returns>
        private List<Book> GetSoughtBooks()
        {
            return soughtBooks;
        }


        /// <summary>
        /// Populated the view tab with the adequate books.
        /// </summary>
        private void PopulateViewTab()
        {
            lbBooks.Items.Clear();

            List<Book> booksSet = GetBooksMethod();

            foreach (Book currentBook in booksSet)
                lbBooks.Items.Add(currentBook);

            lbBooks.SelectedIndex = -1;
        }


        /// <summary>
        /// Changes the title of the selected book in the book listings.
        /// </summary>
        private void ChangeBookTitle()
        {
            PopulateViewTab();

            if (currentBook != null)
            {
                lbBooks.SelectedItem = currentBook;
                bookDetails.SetCurrentBookDetails(currentBook);
            }
        }

        /// <summary>
        /// Deletes the selected book from the books listings.
        /// </summary>
        private void DeleteBook()
        {
            lbBooks.Items.Remove(lbBooks.SelectedItem);
            lbBooks.SelectedIndex = -1;
        }


        public void ResetBooksList()
        {
            tcMain.SelectedTab = tabViewBooks;
            cbViewBooks.SelectedIndex = 0;
            
            currentBook = null;
            bookDetails.SetCurrentBookDetails(currentBook);

            GetBooksMethod = booksManager.BooksRepository.GetAllBooks;
            PopulateViewTab();

            soughtBooks = new List<Book>();
        }


        private void cbViewBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((ViewBooksType)Enum.Parse(typeof(ViewBooksType), cbViewBooks.SelectedItem.ToString().Replace(Space.ToString(), String.Empty), ignoreCase:true))
            {
                case ViewBooksType.AllBooks:
                    bookDetails.ClearDataAndFields();
                    currentBook = null;
                    bookDetails.SetCurrentBookDetails(currentBook);

                    GetBooksMethod = booksManager.BooksRepository.GetAllBooks;
                    PopulateViewTab();

                    soughtBooks = new List<Book>();
                    break;

                case ViewBooksType.CategorizedBooks:
                    bookDetails.ClearDataAndFields();
                    currentBook = null;
                    bookDetails.SetCurrentBookDetails(currentBook);

                    GetBooksMethod = booksManager.BooksRepository.GetCategorizedBooks;
                    PopulateViewTab();

                    soughtBooks = new List<Book>();
                    break;

                case ViewBooksType.UncategorizedBooks:
                    bookDetails.ClearDataAndFields();
                    currentBook = null;
                    bookDetails.SetCurrentBookDetails(currentBook);

                    GetBooksMethod = booksManager.BooksRepository.GetUncategorizedBooks;
                    PopulateViewTab();

                    soughtBooks = new List<Book>();
                    break;

                case ViewBooksType.SoughtBooks:
                    bookDetails.ClearDataAndFields();
                    currentBook = null;
                    bookDetails.SetCurrentBookDetails(currentBook);

                    GetBooksMethod = GetSoughtBooks;
                    PopulateViewTab();

                    break;
            }
        }


        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBooks.SelectedIndex >= 0)
            {
                currentBook = (Book)lbBooks.SelectedItem;
                bookDetails.SetCurrentBookDetails(currentBook);
            }
        }


    }
}
