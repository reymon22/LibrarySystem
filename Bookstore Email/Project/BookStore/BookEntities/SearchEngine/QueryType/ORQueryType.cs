using System;
using System.Collections.Generic;


namespace BookEntities
{

    /// <summary>
    /// OR query class.
    /// </summary>
    public class ORQueryType : IQueryType
    {

        /// <summary>
        /// Performs an OR query on a list of lists of books, returning the resulting list of books.
        /// </summary>
        /// <param name="books">The list of lists of books</param>
        /// <returns>The resulting list of books</returns>
        public List<Book> PerformQuery(List<List<Book>> books)
        {
            List<Book> requestedBooks = new List<Book>();

            foreach (List<Book> currentBook in books)
                requestedBooks = SetOperations<Book>.Union(requestedBooks, currentBook);

            return requestedBooks;
        }

    }

}
