using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Db4objects.Db4o;
using DataAccess;
using DiscAccess;


namespace BookEntities
{

    /// <summary>
    /// Class for managing a book entry.
    /// </summary>
    public class Book : IComparable<Book>
    {
        
        /// <summary>
        /// The folder and file structure, along with its corresponding
        /// content.
        /// </summary>
        public IDiscEntry discEntry;

        /// <summary>
        /// The relative path to the file entry point for the book.
        /// </summary>
        private string entryPointPath;

        /// <summary>
        /// True, if the book is folder based, false, if the book is file based.
        /// </summary>
        private bool isFolderBased;

        /// <summary>
        /// Path to the temporary folder holding the book.
        /// </summary>
        private string tempFolderPath;


        private string title;
        private List<Author> authors;
        private List<Tag> tags;
        private PublishingHouse publishingHouse;
        private YearOfPublishing yearOfPublishing;


        /// <summary>
        /// Book constructor.
        /// </summary>
        /// <param name="discEntry">The folder and file structure, along with its corresponding
        /// content</param>
        /// <param name="entryPointPath">The path to the file entry point for the book</param>
        /// <param name="isFolderBased">True, if the book is folder based,
        /// false, if the book is file based</param>
        /// <param name="title">The title of the book</param>
        public Book(IDiscEntry discEntry, string entryPointPath, bool isFolderBased, string title)
        {
            this.discEntry = discEntry;
            this.entryPointPath = entryPointPath;
            this.isFolderBased = isFolderBased;

            this.title = title;
            this.authors = new List<Author>();
            this.tags = new List<Tag>();
            this.publishingHouse = null;
            this.yearOfPublishing = null;
        }


        public List<Author> Authors
        {
            get 
            { 
                return authors; 
            }
            set 
            {
                try
                {
                    IUpdateAction deleteAuthorsSetAction = new DeleteAction(authors);
                    DatabaseManager.Instance.PerformDataUpdate(deleteAuthorsSetAction);

                    authors = value;
                }

                catch (DatabaseException ex)
                {
                    throw new BookEntitiesException(ex.Message, ex);
                }
            }
        }

        public List<Tag> Tags
        {
            get
            {
                return tags;
            }
            set
            {
                try
                {
                    IUpdateAction deleteTagsSetAction = new DeleteAction(tags);
                    DatabaseManager.Instance.PerformDataUpdate(deleteTagsSetAction);

                    tags = value;
                }

                catch (DatabaseException ex)
                {
                    throw new BookEntitiesException(ex.Message, ex);
                }
            }
        }


        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public PublishingHouse PublishingHouse
        {
            get { return publishingHouse; }
            set { publishingHouse = value; }
        }

        public YearOfPublishing YearOfPublishing
        {
            get { return yearOfPublishing; }
            set { yearOfPublishing = value; }
        }


        public void ReadStructureFromDisc()
        {
            try
            {
                discEntry.ReadStructureFromDisc();
            }

            catch (DiscAccessException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }
        }


        public void DisplayBookContent(string rootPath)
        {
            if (rootPath.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                tempFolderPath = string.Format("{0}{1}", rootPath, Path.DirectorySeparatorChar);
            else
                tempFolderPath = rootPath;

            tempFolderPath = string.Format("{0}{1}{2}{3}", tempFolderPath, title, "_",
                                           DateTime.UtcNow.Ticks.ToString());

            try
            {
                discEntry.SetRootPath(tempFolderPath);
                discEntry.WriteStructureToDisc();
            }

            catch (DiscAccessException ex)
            {
                throw new BookEntitiesException(ex.Message, ex);
            }

            DisplayBookContentProcessLaunch();
        }


        /// <summary>
        /// Displays the book's content, using the application registered on the system to open it.
        /// </summary>
        private void DisplayBookContentProcessLaunch()
        {
            string completePath;
            Process displayFolderProcess, displayBookProcess;
            
            if (tempFolderPath.EndsWith(Path.DirectorySeparatorChar.ToString()) == false)
                completePath = string.Format("{0}{1}", tempFolderPath,
                                             Path.DirectorySeparatorChar);
            else
                completePath = tempFolderPath;
            
            completePath = String.Format("{0}{1}", completePath, entryPointPath);

            try
            {
                if (isFolderBased == true)
                {
                    displayFolderProcess = new Process();
                    displayFolderProcess.StartInfo.FileName = "explorer.exe";
                    displayFolderProcess.StartInfo.Arguments = tempFolderPath;
                    displayFolderProcess.Start();
                }

                displayBookProcess = new Process();
                displayBookProcess.StartInfo.FileName = completePath;
                displayBookProcess.StartInfo.Verb = "Open";  
                displayBookProcess.Start();
            }

            catch (Exception ex)
            {
                throw new BookEntitiesException("Could not access the requested book structure on disc.", ex);
            }
        }


        public int CompareTo(Book other)
        {
            return title.CompareTo(other.title);
        }

        public override string ToString()
        {
            return title;
        }


        private void ObjectOnDelete(IObjectContainer container)
        {
            IUpdateAction deleteDiscEntryAction = new DeleteAction(discEntry);
            IUpdateAction deleteAuthorsAction = new DeleteAction(authors);
            IUpdateAction deleteTagsAction = new DeleteAction(tags);
            DatabaseManager.Instance.PerformDataUpdate(deleteDiscEntryAction, deleteAuthorsAction,
                                                       deleteTagsAction);
        }

    }
}
