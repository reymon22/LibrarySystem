using System;


namespace DiscAccess
{

    
    [Serializable]
    class DiscAccessException : Exception
    {

        
        public DiscAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }

}
