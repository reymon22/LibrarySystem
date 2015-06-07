using System;


namespace RegistryAccess

{
    
   
    [Serializable]
    class RegistryAccessException : Exception
    {

        
        public RegistryAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }

}
