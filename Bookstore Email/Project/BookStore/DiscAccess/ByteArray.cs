namespace DiscAccess
{
    
    /// <summary>
    /// Byte buffer handler class.
    /// </summary>
    class ByteArray
    {

        /// <summary>
        /// Internal buffer.
        /// </summary>
        private byte[] buffer;


        /// <summary>
        /// ByteArray constructor.
        /// </summary>
        /// <param name="buffer">The internal buffer</param>
        public ByteArray(byte[] buffer)
        {
            this.buffer = buffer;
        }


        /// <summary>
        /// Gets the internal buffer.
        /// </summary>
        public byte[] Buffer
        {
            get { return buffer; }
        }

    }

}
