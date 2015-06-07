using System;
using System.Collections.Generic;
using System.IO;

using Db4objects.Db4o;
using DataAccess;


namespace DiscAccess
{
    
    /// <summary>
    /// Custom buffer class, used to enable large data file buffers.
    /// </summary>
    class CustomBuffer
    {
        
        /// <summary>
        /// Buffer size (in bytes).
        /// </summary>
        private const int BufferSize = 6 * 1024 * 1024; // 6 MB buffer
        

        /// <summary>
        /// List of internal byte buffers.
        /// </summary>
        private List<ByteArray> byteBuffers;


        /// <summary>
        /// CustomBuffer constructor.
        /// </summary>
        public CustomBuffer()
        {
            byteBuffers = new List<ByteArray>();
        }


        /// <summary>
        /// Reads a file from disc and stores its content into a list of byte buffer.
        /// </summary>
        /// <param name="completePath">The complete path to the file</param>
        public void ReadFileFromDisc(string completePath)
        {
            try
            {
                byte[] buffer;
                int concreteBufferSize;

                FileInfo info = new FileInfo(completePath);
                int fileSize = (int)info.Length;

                int streamPosition = 0;

                using (FileStream stream = info.OpenRead())
                {
                    while (true)
                    {
                        if (streamPosition + BufferSize < fileSize)
                            concreteBufferSize = BufferSize;
                        else
                            concreteBufferSize = fileSize - streamPosition;

                        buffer = new byte[concreteBufferSize];
                        stream.Read(buffer, 0, concreteBufferSize);
                        streamPosition += concreteBufferSize;

                        ByteArray newByteArray = new ByteArray(buffer);
                        byteBuffers.Add(newByteArray);

                        IUpdateAction addNewByteArrayAction = new UpdateStoreAction(newByteArray);
                        IUpdateAction deactivateNewByteArray = new DeactivateAction(newByteArray, 1);
                        DatabaseManager.Instance.PerformDataUpdate(addNewByteArrayAction,
                                                                   deactivateNewByteArray);

                        if (streamPosition == fileSize)
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new DiscAccessException(String.Format("{0}{1}{2}",
                                             "Could not read the file \"",
                                             completePath,
                                             "\" from disc."), ex);
            }

            finally
            {
                IUpdateAction addByteArrayListAction = new UpdateStoreAction(byteBuffers);
                DatabaseManager.Instance.PerformDataUpdate(addByteArrayListAction);
            }

        }


        /// <summary>
        /// Writes a file to disc, reading it from the list fo buffers.
        /// </summary>
        /// <param name="completePath">The complete path to the file</param>
        public void WriteFileToDisc(string completePath)
        {
            int splitPosition = completePath.LastIndexOf(Path.DirectorySeparatorChar);
            string folderRoot = completePath.Substring(0, splitPosition);

            try
            {
                if (Directory.Exists(folderRoot) == false)
                    Directory.CreateDirectory(folderRoot);

                FileInfo info = new FileInfo(completePath);

                using (FileStream stream = info.OpenWrite())
                {
                    IUpdateAction getByteBuffersAction = new ActivateAction(byteBuffers, 1);
                    DatabaseManager.Instance.PerformDataUpdate(getByteBuffersAction);
                    
                    for (int i = 0 ; i < byteBuffers.Count; i++)
                    {
                        IUpdateAction getIndividualBufferAction = new ActivateAction(byteBuffers[i], 1);
                        DatabaseManager.Instance.PerformDataUpdate(getIndividualBufferAction);

                        stream.Write(byteBuffers[i].Buffer, 0, byteBuffers[i].Buffer.Length);

                        IUpdateAction clearIndividualBufferAction = new DeactivateAction(byteBuffers[i], 1);
                        DatabaseManager.Instance.PerformDataUpdate(clearIndividualBufferAction);
                    }
                }
            }

            catch (Exception ex)
            {
                throw new DiscAccessException(String.Format("{0}{1}{2}",
                                             "Could not write the file \"",
                                             completePath,
                                             "\" to disc."), ex);
            }
        }


        /// <summary>
        /// Removes the structure from the database.
        /// </summary>
        private void ObjectOnDelete(IObjectContainer container)
        {
            try
            {
                for (int i = 0; i < byteBuffers.Count; i++)
                {
                    IUpdateAction activateIndividualBufferAction = new ActivateAction(byteBuffers[i], 1);
                    IUpdateAction deleteIndividualBufferAction = new DeleteAction(byteBuffers[i]);
                    IUpdateAction clearIndividualBufferAction = new DeactivateAction(byteBuffers[i], 1);
                    DatabaseManager.Instance.PerformDataUpdate(activateIndividualBufferAction,
                                                               deleteIndividualBufferAction,
                                                               clearIndividualBufferAction);
                }

                IUpdateAction deleteListOfBuffers = new DeleteAction(byteBuffers);
                IUpdateAction clearListOfBuffers = new DeactivateAction(byteBuffers, 1);
                DatabaseManager.Instance.PerformDataUpdate(deleteListOfBuffers, clearListOfBuffers);
            }

            catch (DatabaseException) { }
        }

    }

}
