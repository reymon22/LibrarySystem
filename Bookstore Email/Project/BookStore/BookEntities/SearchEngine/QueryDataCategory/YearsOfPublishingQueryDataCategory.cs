using System.Collections.Generic;


namespace BookEntities
{

    /// <summary>
    /// YearsOfPublishing intra-category query class.
    /// </summary>
    public class YearsOfPublishingQueryDataCategory : IQueryDataCategory
    {

        /// <summary>
        /// The command-pattern business-logic instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// The list of yearsOfPublishing to query by.
        /// </summary>
        private List<YearOfPublishing> yearsOfPublishing;


        /// <summary>
        /// YearsOfPublishingQueryDataCategory constructor.
        /// </summary>
        /// <param name="booksManager">The command-pattern business-logic instance</param>
        /// <param name="yearsOfPublishing">The list of years of publishing to query by</param>
        public YearsOfPublishingQueryDataCategory(BooksManager booksManager, List<YearOfPublishing> yearsOfPublishing)
        {
            this.booksManager = booksManager;
            this.yearsOfPublishing = yearsOfPublishing;
        }


        /// <summary>
        /// Performs an AND internal query, returning the result list of books.
        /// </summary>
        /// <returns>The result list of books</returns>
        public List<Book> ANDInternalQuery()
        {
            List<Book> requestedBooks = new List<Book>();

            if (yearsOfPublishing.Count > 0)
            {
                requestedBooks = booksManager.BooksRepository.GetAllBooksWithYearOfPublishing(yearsOfPublishing[0]);

                for (int i = 1; i < yearsOfPublishing.Count; i++)
                    requestedBooks = SetOperations<Book>.Intersection(requestedBooks,
                            booksManager.BooksRepository.GetAllBooksWithYearOfPublishing(yearsOfPublishing[i]));
            }

            return requestedBooks;
        }


        /// <summary>
        /// Performs an OR internal query, returning the result list of books.
        /// </summary>
        /// <returns>The result list of books</returns>
        public List<Book> ORInternalQuery()
        {
            List<Book> requestedBooks = new List<Book>();

            foreach (YearOfPublishing aYearOfPublishing in yearsOfPublishing)
                requestedBooks = SetOperations<Book>.Union(requestedBooks,
                            booksManager.BooksRepository.GetAllBooksWithYearOfPublishing(aYearOfPublishing));

            return requestedBooks;

        }

    }

}
