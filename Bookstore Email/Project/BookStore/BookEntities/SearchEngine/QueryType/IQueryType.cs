using System;
using System.Collections.Generic;


namespace BookEntities
{
    
    /// <summary>
    /// Inter-category query interface.
    /// </summary>
    interface IQueryType
    {

        /// <summary>
        /// Performs an AND query on a list of lists of books, returning the resulting list of books.
        /// </summary>
        /// <param name="books">The list of lists of books</param>
        /// <returns>The resulting list of books</returns>
        List<Book> PerformQuery(List<List<Book>> books);

    }

}
