using System;
using System.Collections.Generic;
using System.IO;

using DataAccess;


namespace BookEntities
{
    
    public class BooksData
    {

        private List<Book> books;

        private List<Author> authors;
        private List<Tag> tags;
        private List<PublishingHouse> publishingHouses;
        private List<YearOfPublishing> yearsOfPublishing;

        private Dictionary<Author, List<Book>> booksWithAuthor;
        private Dictionary<Tag, List<Book>> booksWithTag;
        private Dictionary<PublishingHouse, List<Book>> booksWithPublishingHouse;
        private Dictionary<YearOfPublishing, List<Book>> booksWithYearOfPublishing;


        /// <summary>
        /// BooksData constructor.
        /// </summary>
        public BooksData()
        {
            authors = new List<Author>();
            tags = new List<Tag>();
            publishingHouses = new List<PublishingHouse>();
            yearsOfPublishing = new List<YearOfPublishing>();

            booksWithAuthor = new Dictionary<Author, List<Book>>();
            booksWithTag = new Dictionary<Tag, List<Book>>();
            booksWithPublishingHouse = new Dictionary<PublishingHouse, List<Book>>();
            booksWithYearOfPublishing = new Dictionary<YearOfPublishing, List<Book>>();

            books = new List<Book>();
        }


        /// <summary>
        /// Gets the list of the authors.
        /// </summary>
        public List<Author> Authors
        {
            get { return authors; }
        }

        /// <summary>
        /// Gets the list of the tags.
        /// </summary>
        public List<Tag> Tags
        {
            get { return tags; }
        }

        /// <summary>
        /// Gets the list of the publishing houses.
        /// </summary>
        public List<PublishingHouse> PublishingHouses
        {
            get { return publishingHouses; }
        }

        /// <summary>
        /// Gets the list of the years of publishing.
        /// </summary>
        public List<YearOfPublishing> YearsOfPublishing
        {
            get { return yearsOfPublishing; }
        }


        /// <summary>
        /// Gets the list of all the books.
        /// </summary>
        public List<Book> GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();

            foreach (Book currentBook in books)
                allBooks.Add(currentBook);

            return allBooks;
        }

        /// <summary>
        /// Gets the list of the categorized books.
        /// </summary>
        public List<Book> GetCategorizedBooks()
        {
            List<Book> categorizedBooks = new List<Book>();

            foreach (Book currentBook in books)
                if ((currentBook.Authors.Count > 0) ||
                     (currentBook.Tags.Count > 0) ||
                     (currentBook.PublishingHouse != null) ||
                     (currentBook.YearOfPublishing != null))
                    categorizedBooks.Add(currentBook);

            return categorizedBooks;
        }

        /// <summary>
        /// Gets the list of the uncategorized books.
        /// </summary>
        public List<Book> GetUncategorizedBooks()
        {
            List<Book> uncategorizedBooks = new List<Book>();

            foreach (Book currentBook in books)
                if ((currentBook.Authors.Count == 0) &&
                     (currentBook.Tags.Count == 0) &&
                     (currentBook.PublishingHouse == null) &&
                     (currentBook.YearOfPublishing == null))
                    uncategorizedBooks.Add(currentBook);

            return uncategorizedBooks;
        }


        /// <summary>
        /// Adds a new author to the authors list.
        /// </summary>
        /// <param name="newAuthor">The new author</param>
        public void AddAuthor(Author newAuthor)
        {
            bool authorExists = false;

            foreach (Author anAuthor in authors)
                if (anAuthor.Name == newAuthor.Name)
                {
                    authorExists = true;
                    break;
                }

            if (authorExists == false)
            {
                authors.Add(newAuthor);
                authors.Sort();
                booksWithAuthor[newAuthor] = new List<Book>();
            }
        }

        /// <summary>
        /// Renames an existing author.
        /// </summary>
        /// <param name="authorToRename">The author to be renamed</param>
        /// <param name="newName">The new name for the author</param>
        public void RenameAuthor(Author authorToRename, string newName)
        {
            bool newNameExists = false;

            foreach (Author anAuthor in authors)
                if (anAuthor.Name == newName)
                {
                    newNameExists = true;
                    break;
                }

            if (newNameExists == false)
            {
                authorToRename.Name = newName;
                authors.Sort();
            }
        }

        /// <summary>
        /// Removes an author from the authors list, as well as from the respective books list.
        /// </summary>
        /// <param name="authorToRemove">The author to remove</param>
        public void RemoveAuthor(Author authorToRemove)
        {
            IUpdateAction removeBooksWithAuthorAction = new DummyAction();
            
            authors.Remove(authorToRemove);

            if (booksWithAuthor.ContainsKey(authorToRemove) == true)
            {
                removeBooksWithAuthorAction = new DeleteAction(booksWithAuthor[authorToRemove]);

                foreach (Book currentBook in booksWithAuthor[authorToRemove])
                    currentBook.Authors.Remove(authorToRemove);

                booksWithAuthor.Remove(authorToRemove);
            }

            try
            {
                IUpdateAction removeAuthorAction = new DeleteAction(authorToRemove);
                DatabaseManager.Instance.PerformDataUpdate(removeBooksWithAuthorAction, removeAuthorAction);
            }

            catch (DatabaseException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Adds a new tag to the tags list.
        /// </summary>
        /// <param name="newTag">The new tag</param>
        public void AddTag(Tag newTag)
        {
            bool tagExists = false;

            foreach (Tag aTag in tags)
                if (aTag.Name == newTag.Name)
                {
                    tagExists = true;
                    break;
                }

            if (tagExists == false)
            {
                tags.Add(newTag);
                tags.Sort();
                booksWithTag[newTag] = new List<Book>();
            }
        }

        /// <summary>
        /// Renames an existing tag.
        /// </summary>
        /// <param name="tagToRename">The tag to be renamed</param>
        /// <param name="newName">The new name for the tag</param>
        public void RenameTag(Tag tagToRename, string newName)
        {
            bool newNameExists = false;

            foreach (Tag aTag in tags)
                if (aTag.Name == newName)
                {
                    newNameExists = true;
                    break;
                }

            if (newNameExists == false)
            {
                tagToRename.Name = newName;
                tags.Sort();
            }
        }

        /// <summary>
        /// Removes a tag from the tags list, as well as from the respective books list.
        /// </summary>
        /// <param name="tagToRemove">The tag to remove</param>
        public void RemoveTag(Tag tagToRemove)
        {
            IUpdateAction removeBooksWithTagAction = new DummyAction();
            
            tags.Remove(tagToRemove);

            if (booksWithTag.ContainsKey(tagToRemove) == true)
            {
                removeBooksWithTagAction = new DeleteAction(booksWithTag[tagToRemove]);

                foreach (Book currentBook in booksWithTag[tagToRemove])
                    currentBook.Tags.Remove(tagToRemove);

                booksWithTag.Remove(tagToRemove);
            }

            try
            {
                IUpdateAction removeTagAction = new DeleteAction(tagToRemove);
                DatabaseManager.Instance.PerformDataUpdate(removeBooksWithTagAction, removeTagAction);
            }

            catch (DatabaseException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Adds a new publishing house to the publishing houses list.
        /// </summary>
        /// <param name="newPublishingHouse">The new publishing house</param>
        public void AddPublishingHouse(PublishingHouse newPublishingHouse)
        {
            bool publishingHouseExists = false;

            foreach (PublishingHouse aPublishingHouse in publishingHouses)
                if (aPublishingHouse.Name == newPublishingHouse.Name)
                {
                    publishingHouseExists = true;
                    break;
                }

            if (publishingHouseExists == false)
            {
                publishingHouses.Add(newPublishingHouse);
                publishingHouses.Sort();
                booksWithPublishingHouse[newPublishingHouse] = new List<Book>();
            }
        }

        /// <summary>
        /// Renames an existing publishing house.
        /// </summary>
        /// <param name="publishingHouseToRename">The publishing house to be renamed</param>
        /// <param name="newName">The new name for the publishing house</param>
        public void RenamePublishingHouse(PublishingHouse publishingHouseToRename, string newName)
        {
            bool newNameExists = false;

            foreach (PublishingHouse aPublishingHouse in publishingHouses)
                if (aPublishingHouse.Name == newName)
                {
                    newNameExists = true;
                    break;
                }

            if (newNameExists == false)
            {
                publishingHouseToRename.Name = newName;
                publishingHouses.Sort();
            }
        }

        /// <summary>
        /// Removes a publishing house from the publishing houses list, as well as
        /// from the respective books list.
        /// </summary>
        /// <param name="publishingHouseToRemove">The publishing house to remove</param>
        public void RemovePublishingHouse(PublishingHouse publishingHouseToRemove)
        {
            IUpdateAction removeBooksWithPublishingHouseAction = new DummyAction();
            
            publishingHouses.Remove(publishingHouseToRemove);

            if (booksWithPublishingHouse.ContainsKey(publishingHouseToRemove) == true)
            {
                removeBooksWithPublishingHouseAction = new DeleteAction(
                                            booksWithPublishingHouse[publishingHouseToRemove]);

                foreach (Book currentBook in booksWithPublishingHouse[publishingHouseToRemove])
                    currentBook.PublishingHouse = null;

                booksWithPublishingHouse.Remove(publishingHouseToRemove);
            }

            try
            {
                IUpdateAction removePublishingHouseAction = new DeleteAction(publishingHouseToRemove);
                DatabaseManager.Instance.PerformDataUpdate(removeBooksWithPublishingHouseAction,
                                                           removePublishingHouseAction);
            }

            catch (DatabaseException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Adds a new year of publishing to the years of publishing list.
        /// </summary>
        /// <param name="newYearOfPublishing">The new year of publishing</param>
        public void AddYearOfPublishing(int newYearOfPublishing)
        {
            bool yearOfPublishingExists = false;

            foreach (YearOfPublishing aYearOfPublishing in yearsOfPublishing)
                if (aYearOfPublishing.Year == newYearOfPublishing)
                {
                    yearOfPublishingExists = true;
                    break;
                }

            if (yearOfPublishingExists == false)
            {
                YearOfPublishing newYearOfPublishingObject = new YearOfPublishing(newYearOfPublishing);
                yearsOfPublishing.Add(newYearOfPublishingObject);
                yearsOfPublishing.Sort();
                booksWithYearOfPublishing[newYearOfPublishingObject] = new List<Book>();
            }
        }

        /// <summary>
        /// Renames an existing year of publishing.
        /// </summary>
        /// <param name="yearOfPublishingToRename">The year of publishing to be renamed</param>
        /// <param name="newYear">The new year for the year of publishing</param>
        public void RenameYearOfPublishing(YearOfPublishing yearOfPublishingToRename, int newYear)
        {
            bool newYearExists = false;

            foreach (YearOfPublishing aYearOfPublishing in yearsOfPublishing)
                if (aYearOfPublishing.Year == newYear)
                {
                    newYearExists = true;
                    break;
                }

            if (newYearExists == false)
            {
                yearOfPublishingToRename.Year = newYear;
                yearsOfPublishing.Sort();
            }
        }

        /// <summary>
        /// Removes a year of publishing from the years of publishing list, as well as
        /// from the respective books list.
        /// </summary>
        /// <param name="yearOfPublishingToRemove">The year of publishing to remove</param>
        public void RemoveYearOfPublishing(YearOfPublishing yearOfPublishingToRemove)
        {
            IUpdateAction removeBooksWithYearOfPublishingAction = new DummyAction();
            
            yearsOfPublishing.Remove(yearOfPublishingToRemove);

            if (booksWithYearOfPublishing.ContainsKey(yearOfPublishingToRemove) == true)
            {
                removeBooksWithYearOfPublishingAction = new DeleteAction(
                                                booksWithYearOfPublishing[yearOfPublishingToRemove]);

                foreach (Book currentBook in booksWithYearOfPublishing[yearOfPublishingToRemove])
                    currentBook.YearOfPublishing = null;

                booksWithYearOfPublishing.Remove(yearOfPublishingToRemove);
            }

            try
            {
                IUpdateAction removeYearOfPublishingAction = new DeleteAction(yearOfPublishingToRemove);
                DatabaseManager.Instance.PerformDataUpdate(removeBooksWithYearOfPublishingAction,
                                                           removeYearOfPublishingAction);
            }

            catch (DatabaseException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Adds a new book to the list of books.
        /// </summary>
        /// <param name="newBook">The new book</param>
        public void AddNewBook(Book newBook)
        {
            books.Add(newBook);

            UpdateDatabase();
        }

        /// <summary>
        /// Removes a book from the list of books, as well as from the database.
        /// </summary>
        /// <param name="bookToRemove">The book to be removed</param>
        public void RemoveBook(Book bookToRemove)
        {
            books.Remove(bookToRemove);

            foreach (Author currentAuthor in booksWithAuthor.Keys)
                booksWithAuthor[currentAuthor].Remove(bookToRemove);

            foreach (Tag currentTag in booksWithTag.Keys)
                booksWithTag[currentTag].Remove(bookToRemove);

            foreach (PublishingHouse currentPublishingHouse in booksWithPublishingHouse.Keys)
                booksWithPublishingHouse[currentPublishingHouse].Remove(bookToRemove);

            foreach (YearOfPublishing currentYearOfPublishing in booksWithYearOfPublishing.Keys)
                booksWithYearOfPublishing[currentYearOfPublishing].Remove(bookToRemove);

            try
            {
                IUpdateAction removeBook = new DeleteAction(bookToRemove);
                DatabaseManager.Instance.PerformDataUpdate(removeBook);
            }

            catch (DatabaseException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }

            UpdateDatabase();
        }


        public void SetBookAuthors(Book currentBook, List<Author> bookAuthors)
        {
            if (currentBook.Authors != null)
                foreach (Author currentAuthor in currentBook.Authors)
                    if (booksWithAuthor.ContainsKey(currentAuthor) == true)
                        booksWithAuthor[currentAuthor].Remove(currentBook);

            currentBook.Authors = bookAuthors;

            foreach (Author currentAuthor in currentBook.Authors)
                if (booksWithAuthor.ContainsKey(currentAuthor) == true)
                    booksWithAuthor[currentAuthor].Add(currentBook);
        }


        public void SetBookTags(Book currentBook, List<Tag> bookTags)
        {
            if (currentBook.Tags != null)
                foreach (Tag currentTag in currentBook.Tags)
                    if (booksWithTag.ContainsKey(currentTag) == true)
                        booksWithTag[currentTag].Remove(currentBook);

            currentBook.Tags = bookTags;

            foreach (Tag currentTag in currentBook.Tags)
                if (booksWithTag.ContainsKey(currentTag) == true)
                    booksWithTag[currentTag].Add(currentBook);
        }


        public void SetBookPublishingHouse(Book currentBook, PublishingHouse bookPublishingHouse)
        {
            if (currentBook.PublishingHouse != null)
                if (booksWithPublishingHouse.ContainsKey(currentBook.PublishingHouse) == true)
                    booksWithPublishingHouse[currentBook.PublishingHouse].Remove(currentBook);

            currentBook.PublishingHouse = bookPublishingHouse;

            if ((currentBook.PublishingHouse != null) && (bookPublishingHouse != null))
                if (booksWithPublishingHouse.ContainsKey(bookPublishingHouse) == true)
                    booksWithPublishingHouse[bookPublishingHouse].Add(currentBook);
        }


        public void SetBookYearOfPublishing(Book currentBook, YearOfPublishing bookYearOfPublishing)
        {
            if (currentBook.YearOfPublishing != null)
                if (booksWithYearOfPublishing.ContainsKey(currentBook.YearOfPublishing) == true)
                    booksWithYearOfPublishing[currentBook.YearOfPublishing].Remove(currentBook);

            currentBook.YearOfPublishing = bookYearOfPublishing;

            if ((currentBook.YearOfPublishing != null) && (bookYearOfPublishing != null))
                if (booksWithYearOfPublishing.ContainsKey(bookYearOfPublishing) == true)
                    booksWithYearOfPublishing[bookYearOfPublishing].Add(currentBook);
        }


        public List<Book> GetAllBooksWithAuthor(Author anAuthor)
        {
            List<Book> requiredBooks = new List<Book>();

            if (booksWithAuthor.ContainsKey(anAuthor) == true)
                foreach (Book aBook in booksWithAuthor[anAuthor])
                    requiredBooks.Add(aBook);

            return requiredBooks;
        }

        public List<Book> GetAllBooksWithTag(Tag aTag)
        {
            List<Book> requiredBooks = new List<Book>();

            if (booksWithTag.ContainsKey(aTag) == true)
                foreach (Book aBook in booksWithTag[aTag])
                    requiredBooks.Add(aBook);

            return requiredBooks;
        }

        public List<Book> GetAllBooksWithPublishingHouse(PublishingHouse aPublishingHouse)
        {
            List<Book> requiredBooks = new List<Book>();

            if (booksWithPublishingHouse.ContainsKey(aPublishingHouse) == true)
                foreach (Book aBook in booksWithPublishingHouse[aPublishingHouse])
                    requiredBooks.Add(aBook);

            return requiredBooks;
        }

        public List<Book> GetAllBooksWithYearOfPublishing(YearOfPublishing aYearOfPublishing)
        {
            List<Book> requiredBooks = new List<Book>();

            if (booksWithYearOfPublishing.ContainsKey(aYearOfPublishing) == true)
                foreach (Book aBook in booksWithYearOfPublishing[aYearOfPublishing])
                    requiredBooks.Add(aBook);

            return requiredBooks;
        }


        public void UpdateDatabase()
        {
            try
            {
                IUpdateAction updateBooksDataAction = new UpdateStoreAction(this);
                DatabaseManager.Instance.PerformDataUpdate(updateBooksDataAction);
            }

            catch (DatabaseException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }

    }

}
