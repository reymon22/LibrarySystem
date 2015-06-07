using System.Collections.Generic;


namespace BookEntities
{

    /// <summary>
    /// Tags intra-category query class.
    /// </summary>
    public class TagsQueryDataCategory : IQueryDataCategory
    {

        /// <summary>
        /// The command-pattern business-logic instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// The list of tags to query by.
        /// </summary>
        private List<Tag> tags;


        /// <summary>
        /// TagsQueryDataCategory constructor.
        /// </summary>
        /// <param name="booksManager">The command-pattern business-logic instance</param>
        /// <param name="tags">The list of tags to query by</param>
        public TagsQueryDataCategory(BooksManager booksManager, List<Tag> tags)
        {
            this.booksManager = booksManager;
            this.tags = tags;
        }


        /// <summary>
        /// Performs an AND internal query, returning the result list of books.
        /// </summary>
        /// <returns>The result list of books</returns>
        public List<Book> ANDInternalQuery()
        {
            List<Book> requestedBooks = new List<Book>();

            if (tags.Count > 0)
            {
                requestedBooks = booksManager.BooksRepository.GetAllBooksWithTag(tags[0]);

                for (int i = 1; i < tags.Count; i++)
                    requestedBooks = SetOperations<Book>.Intersection(requestedBooks,
                            booksManager.BooksRepository.GetAllBooksWithTag(tags[i]));
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

            foreach (Tag aTag in tags)
                requestedBooks = SetOperations<Book>.Union(requestedBooks,
                            booksManager.BooksRepository.GetAllBooksWithTag(aTag));

            return requestedBooks;

        }

    }

}
