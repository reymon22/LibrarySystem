using System;


namespace DataAccess
{

    /// <summary>
    /// Exception class pertaining to the database functionality.
    /// </summary>
    [Serializable]
    class DatabaseException : Exception
    {

        /// <summary>
        /// DatabaseException constructor.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner exception</param>
        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }

}
