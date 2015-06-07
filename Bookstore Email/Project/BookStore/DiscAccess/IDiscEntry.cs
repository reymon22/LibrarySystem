using System;
using System.Collections.Generic;


namespace DiscAccess
{

    /// <summary>
    /// Interface for managing the reading and writing of files and folders to / from the disc.
    /// </summary>
    public interface IDiscEntry
    {

        /// <summary>
        /// Gets the name of the file or folder.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the path of the file or folder.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Reads the folder and file structure from disc.
        /// </summary>
        void ReadStructureFromDisc();

        /// <summary>
        /// Sets the root path to the folder (or file) holding the content.
        /// </summary>
        /// <param name="rootPath">The root path to the folder (or file) holding the content</param>
        void SetRootPath(string rootPath);

        /// <summary>
        /// Writes the folder and file structure to disc.
        /// </summary>
        void WriteStructureToDisc();

        /// <summary>
        /// Deletes the folder and file structure from disc.
        /// </summary>
        void DeleteStructureFromDisc();

        /// <summary>
        /// Loads all the individual files from the folder and file structure.
        /// </summary>
        /// <param name="filesList">The list of individual files from the folder and file structure</param>
        void BulkLoadSingleFiles(List<IDiscEntry> filesList);

    }

}
