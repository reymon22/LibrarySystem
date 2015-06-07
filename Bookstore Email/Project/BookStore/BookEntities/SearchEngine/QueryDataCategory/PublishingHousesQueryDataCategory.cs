using System.Collections.Generic;


namespace BookEntities
{

    /// <summary>
    /// PublishingHouses intra-category query class.
    /// </summary>
    public class PublishingHousesQueryDataCategory : IQueryDataCategory
    {

        /// <summary>
        /// The command-pattern business-logic instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// The list of publishingHouses to query by.
        /// </summary>
        private List<PublishingHouse> publishingHouses;


        /// <summary>
        /// PublishingHousesQueryDataCategory constructor.
        /// </summary>
        /// <param name="booksManager">The command-pattern business-logic instance</param>
        /// <param name="publishingHouses">The list of publishing houses to query by</param>
        public PublishingHousesQueryDataCategory(BooksManager booksManager, List<PublishingHouse> publishingHouses)
        {
            this.booksManager = booksManager;
            this.publishingHouses = publishingHouses;
        }


        /// <summary>
        /// Performs an AND internal query, returning the result list of books.
        /// </summary>
        /// <returns>The result list of books</returns>
        public List<Book> ANDInternalQuery()
        {
            List<Book> requestedBooks = new List<Book>();

            if (publishingHouses.Count > 0)
            {
                requestedBooks = booksManager.BooksRepository.GetAllBooksWithPublishingHouse(publishingHouses[0]);

                for (int i = 1; i < publishingHouses.Count; i++)
                    requestedBooks = SetOperations<Book>.Intersection(requestedBooks,
                            booksManager.BooksRepository.GetAllBooksWithPublishingHouse(publishingHouses[i]));
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

            foreach (PublishingHouse aPublishingHouse in publishingHouses)
                requestedBooks = SetOperations<Book>.Union(requestedBooks,
                            booksManager.BooksRepository.GetAllBooksWithPublishingHouse(aPublishingHouse));

            return requestedBooks;

        }

    }

}
