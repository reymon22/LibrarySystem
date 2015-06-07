using System;
using System.Collections.Generic;
using System.IO;


namespace DiscAccess
{

    /// <summary>
    /// Represents a file on the disc.
    /// </summary>
    class File : IDiscEntry
    {

        /// <summary>
        /// The root path to the file.
        /// </summary>
        private string rootPath;

        /// <summary>
        /// The path to the file, starting from the root path.
        /// </summary>
        private string path;

        /// <summary>
        /// The complete path to the file.
        /// </summary>
        private string completePath;

        /// <summary>
        /// The file content representation.
        /// </summary>
        private CustomBuffer customBuffer;


        /// <summary>
        /// File constructor.
        /// </summary>
        /// <param name="rootPath">The root path to the file</param>
        /// <param name="path">The path to the file, starting from the root path</param>
        public File(string rootPath, string path)
        {
            this.path = path;
            this.customBuffer = new CustomBuffer();

            SetRootPath(rootPath);
        }


        /// <summary>
        /// Gets the name of the file or folder.
        /// </summary>
        public string Name
        {
            get
            {
                string name;
                int splitPosition = path.LastIndexOf(System.IO.Path.DirectorySeparatorChar);

                if (splitPosition < 0)
                    name = path;
                else
                    name = path.Substring(splitPosition + 1);

                return name;
            }
        }


        /// <summary>
        /// Gets the path of the file or folder.
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }
        }


        /// <summary>
        /// Reads the file from disc.
        /// </summary>
        public void ReadStructureFromDisc()
        {
            customBuffer.ReadFileFromDisc(completePath);
        }


        /// <summary>
        /// Sets the root path to the folder (or file) holding the content.
        /// </summary>
        /// <param name="rootPath">The root path to the folder (or file) holding the content</param>
        public void SetRootPath(string rootPath)
        {
            if (rootPath == string.Empty)
                throw new DiscAccessException("The file root path cannot be empty.",
                                              new ArgumentNullException("rootPath"));
            
            if (rootPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) == true)
                this.rootPath = rootPath.Substring(0, rootPath.Length - 1);
            else
                this.rootPath = rootPath;

            this.completePath = String.Format("{0}{1}{2}", this.rootPath, System.IO.Path.DirectorySeparatorChar, path);
        }


        /// <summary>
        /// Writes the file to disc.
        /// </summary>
        public void WriteStructureToDisc()
        {
            customBuffer.WriteFileToDisc(completePath);
        }


        /// <summary>
        /// Deletes the file from disc.
        /// </summary>
        public void DeleteStructureFromDisc()
        {
            try
            {
                FileInfo info = new FileInfo(completePath);
                info.Delete();
            }
            catch (Exception) { }
        }


        /// <summary>
        /// Loads all the individual files from the folder and file structure.
        /// </summary>
        /// <param name="filesList">The list of individual files from the folder and file structure</param>
        public void BulkLoadSingleFiles(List<IDiscEntry> filesList)
        {
            filesList.Add(this);
        }

    }

}
