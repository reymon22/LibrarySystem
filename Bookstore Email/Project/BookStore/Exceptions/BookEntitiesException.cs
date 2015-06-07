using System;


namespace BookEntities

{
    
    
    [Serializable]
    class BookEntitiesException : Exception
    {

        
        public BookEntitiesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }

}
