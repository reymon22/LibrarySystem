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
        /// Refreshes the data pertaining to the book search categories.
        /// </summary>
        private void RefreshSearchForBooksTab()
        {
            bookQueryAuthors.RefreshData();
            bookQueryTags.RefreshData();
            bookQueryPublishingHouse.RefreshData();
            bookQueryYearOfPublishing.RefreshData();
        }
        
        
        /// <summary>
        /// Sets the list of books, corresponding to the query, to be accesible in the view books tab.
        /// </summary>
        /// <param name="booksMetaData">The set of books corresponding to the query</param>
        private void SetSoughtBooks(List<Book> books)
        {
            tcMain.SelectedTab = tabViewBooks;
            cbViewBooks.SelectedIndex = cbViewBooks.FindString("All books");
            
            soughtBooks = books;

            cbViewBooks.SelectedIndex = cbViewBooks.FindString("Sought books");
        }


        /// <summary>
        /// Populates the search tab with its repective search categories.
        /// </summary>
        private void PopulateTabSearch()
        {
            bookQueryAuthors = new BookQueryControl(booksManager, typeof(Author), QueryType.ANDORQuery);
            queryTabs.Add(bookQueryAuthors);
            flpQueryControls.Controls.Add(bookQueryAuthors);

            bookQueryTags = new BookQueryControl(booksManager, typeof(Tag), QueryType.ANDORQuery);
            queryTabs.Add(bookQueryTags);
            flpQueryControls.Controls.Add(bookQueryTags);

            bookQueryPublishingHouse = new BookQueryControl(booksManager, typeof(PublishingHouse), QueryType.ORQuery);
            queryTabs.Add(bookQueryPublishingHouse);
            flpQueryControls.Controls.Add(bookQueryPublishingHouse);

            bookQueryYearOfPublishing = new BookQueryControl(booksManager, typeof(YearOfPublishing), QueryType.ORQuery);
            queryTabs.Add(bookQueryYearOfPublishing);
            flpQueryControls.Controls.Add(bookQueryYearOfPublishing);
        }


        private void btPerformQuery_Click(object sender, EventArgs e)
        {
            IQueryType queryType;
            List<List<Book>> booksList = new List<List<Book>>(4);

            foreach (BookQueryControl currentControl in queryTabs)
                if (currentControl.IsChecked == true)
                    booksList.Add(currentControl.CorrespondingBooks);

            if (cbQueryType.SelectedItem.ToString() == "OR")
                queryType = new ORQueryType();
            else
                queryType = new ANDQueryType();

            List<Book> queriedBooksList = queryType.PerformQuery(booksList);
            SetSoughtBooks(queriedBooksList);
        }

    }

}
