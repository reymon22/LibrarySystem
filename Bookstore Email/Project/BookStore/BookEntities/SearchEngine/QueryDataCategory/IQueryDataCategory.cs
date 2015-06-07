using System.Collections.Generic;


namespace BookEntities
{
    
    /// <summary>
    /// Intra-category query interface. 
    /// </summary>
    public interface IQueryDataCategory
    {
        
        /// <summary>
        /// Performs an AND internal query, returning the result list of books.
        /// </summary>
        /// <returns>The result list of books</returns>
        List<Book> ANDInternalQuery();


        /// <summary>
        /// Performs an OR internal query, returning the result list of books.
        /// </summary>
        /// <returns>The result list of books</returns>
        List<Book> ORInternalQuery();

    }

}
