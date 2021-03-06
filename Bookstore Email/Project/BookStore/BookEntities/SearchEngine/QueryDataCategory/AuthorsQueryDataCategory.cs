﻿using System.Collections.Generic;


namespace BookEntities
{
    
    /// <summary>
    /// Authors intra-category query class.
    /// </summary>
    public class AuthorsQueryDataCategory : IQueryDataCategory
    {

        /// <summary>
        /// The command-pattern business-logic instance.
        /// </summary>
        private BooksManager booksManager;

        /// <summary>
        /// The list of authors to query by.
        /// </summary>
        private List<Author> authors;


        /// <summary>
        /// AuthorsQueryDataCategory constructor.
        /// </summary>
        /// <param name="booksManager">The command-pattern business-logic instance</param>
        /// <param name="authors">The list of authors to query by</param>
        public AuthorsQueryDataCategory(BooksManager booksManager, List<Author> authors)
        {
            this.booksManager = booksManager;
            this.authors = authors;
        }


        /// <summary>
        /// Performs an AND internal query, returning the result list of books.
        /// </summary>
        /// <returns>The result list of books</returns>
        public List<Book> ANDInternalQuery()
        {
            List<Book> requestedBooks = new List<Book>();

            if (authors.Count > 0)
            {
                requestedBooks = booksManager.BooksRepository.GetAllBooksWithAuthor(authors[0]);

                for (int i = 1; i < authors.Count; i++)
                    requestedBooks = SetOperations<Book>.Intersection(requestedBooks,
                                            booksManager.BooksRepository.GetAllBooksWithAuthor(authors[i]));
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

            foreach (Author anAuthor in authors)
                requestedBooks = SetOperations<Book>.Union(requestedBooks,
                                            booksManager.BooksRepository.GetAllBooksWithAuthor(anAuthor));

            return requestedBooks;

        }

    }

}
