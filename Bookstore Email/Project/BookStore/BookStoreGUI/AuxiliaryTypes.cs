using System.Collections.Generic;

using BookEntities;


namespace BookStoreGUI
{
    
    delegate void ChangeBookTitleDelegate();
    delegate void DeleteBookDelegate(); 
    delegate List<Book> GetBooks();
    delegate void SetBooks(List<Book> books);
    enum QueryType { ORQuery, ANDORQuery };

    enum ViewBooksType { AllBooks, CategorizedBooks, UncategorizedBooks, SoughtBooks };
}
