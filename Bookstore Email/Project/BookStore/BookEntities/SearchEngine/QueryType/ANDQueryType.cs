using System;
using System.Collections.Generic;


namespace BookEntities
{

    /// <summary>
    /// AND query class. 
    /// </summary>
    public class ANDQueryType : IQueryType
    {

        /// <summary>
        /// Performs an AND query on a list of lists of books, returning the resulting list of books.
        /// </summary>
        /// <param name="books">The list of lists of books</param>
        /// <returns>The resulting list of books</returns>
        public List<Book> PerformQuery(List<List<Book>> books)
        {
            List<Book> requestedBooks;

            if (books.Count == 0)
                requestedBooks = new List<Book>();

            else
            {
                requestedBooks = books[0];

                for (int i = 1; i < books.Count; i++)
                    requestedBooks = SetOperations<Book>.Intersection(requestedBooks, books[i]);
            }

            return requestedBooks;
        }

    }

}
