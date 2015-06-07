using System;
using System.Collections.Generic;

using DiscAccess;
using BookEntities;


namespace DataAccess
{
    
    static class DBSpecificConfiguration
    {

        public static void SetConfiguration()
        {
            DBConfiguration.SetCascadeOnActivate(typeof(BooksData));
            DBConfiguration.SetCascadeOnActivate(typeof(Dictionary<Author, List<Book>>));
            DBConfiguration.SetCascadeOnActivate(typeof(Dictionary<Tag, List<Book>>));
            DBConfiguration.SetCascadeOnActivate(typeof(Dictionary<PublishingHouse, List<Book>>));
            DBConfiguration.SetCascadeOnActivate(typeof(Dictionary<YearOfPublishing, List<Book>>));
            DBConfiguration.SetCascadeOnActivate(typeof(List<Book>));
            DBConfiguration.SetCascadeOnActivate(typeof(Book));
            DBConfiguration.SetCascadeOnActivate(typeof(List<Author>));
            DBConfiguration.SetCascadeOnActivate(typeof(List<Tag>));
            DBConfiguration.SetCascadeOnActivate(typeof(List<PublishingHouse>));
            DBConfiguration.SetCascadeOnActivate(typeof(List<YearOfPublishing>));
            DBConfiguration.SetCascadeOnActivate(typeof(Author));
            DBConfiguration.SetCascadeOnActivate(typeof(Tag));
            DBConfiguration.SetCascadeOnActivate(typeof(PublishingHouse));
            DBConfiguration.SetCascadeOnActivate(typeof(YearOfPublishing));
            DBConfiguration.SetCascadeOnActivate(typeof(Folder));
            DBConfiguration.SetCascadeOnActivate(typeof(File));
            DBConfiguration.SetCascadeOnActivate(typeof(List<IDiscEntry>));
            DBConfiguration.SetCascadeOnActivate(typeof(CustomBuffer));

            DBConfiguration.SetCascadeOnDelete(typeof(Folder));
            DBConfiguration.SetCascadeOnDelete(typeof(File));
            DBConfiguration.SetCascadeOnDelete(typeof(List<IDiscEntry>));
            DBConfiguration.SetCascadeOnDelete(typeof(CustomBuffer));

            DBConfiguration.SetCascadeOnUpdate(typeof(BooksData));
            DBConfiguration.SetCascadeOnUpdate(typeof(Dictionary<Author, List<Book>>));
            DBConfiguration.SetCascadeOnUpdate(typeof(Dictionary<Tag, List<Book>>));
            DBConfiguration.SetCascadeOnUpdate(typeof(Dictionary<PublishingHouse, List<Book>>));
            DBConfiguration.SetCascadeOnUpdate(typeof(Dictionary<YearOfPublishing, List<Book>>));
            DBConfiguration.SetCascadeOnUpdate(typeof(List<Book>));
            DBConfiguration.SetCascadeOnUpdate(typeof(Book));
            DBConfiguration.SetCascadeOnUpdate(typeof(List<Author>));
            DBConfiguration.SetCascadeOnUpdate(typeof(List<Tag>));
            DBConfiguration.SetCascadeOnUpdate(typeof(List<PublishingHouse>));
            DBConfiguration.SetCascadeOnUpdate(typeof(List<YearOfPublishing>));
            DBConfiguration.SetCascadeOnUpdate(typeof(Author));
            DBConfiguration.SetCascadeOnUpdate(typeof(Tag));
            DBConfiguration.SetCascadeOnUpdate(typeof(PublishingHouse));
            DBConfiguration.SetCascadeOnUpdate(typeof(YearOfPublishing));
            DBConfiguration.SetCascadeOnUpdate(typeof(Folder));
            DBConfiguration.SetCascadeOnUpdate(typeof(File));
            DBConfiguration.SetCascadeOnUpdate(typeof(List<IDiscEntry>));
            DBConfiguration.SetCascadeOnUpdate(typeof(CustomBuffer));
        }

    }

}
