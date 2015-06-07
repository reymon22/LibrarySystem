namespace BookStoreGUI
{

    
    class BooksListOperations
    {

       
        private ChangeBookTitleDelegate ChangeBookTitleMethod;

        
        private DeleteBookDelegate DeleteBookMethod;


        
        public BooksListOperations(ChangeBookTitleDelegate ChangeBookTitleMethod,
                                   DeleteBookDelegate DeleteBookMethod)
        {
            this.ChangeBookTitleMethod = ChangeBookTitleMethod;
            this.DeleteBookMethod = DeleteBookMethod;
        }

        public void ChangeBookTitle()
        {
            ChangeBookTitleMethod();
        }

        public void DeleteBook()
        {
            DeleteBookMethod();
        }

    }

}
