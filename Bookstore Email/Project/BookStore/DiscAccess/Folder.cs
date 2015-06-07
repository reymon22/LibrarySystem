using System;
using System.Collections.Generic;
using System.IO;


namespace DiscAccess
{

    /// <summary>
    /// Represents a folder on the disc.
    /// </summary>
    class Folder : IDiscEntry
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
        /// The complete path to the folder.
        /// </summary>
        private string completePath;

        /// <summary>
        /// The folders and files subtree structure of the current folder.
        /// </summary>
        private List<IDiscEntry> subStructure;


        /// <summary>
        /// Folder constructor.
        /// </summary>
        /// <param name="rootPath">The root path to the folder</param>
        /// <param name="path">The path to the folder, starting from the root path</param>
        public Folder(string rootPath, string path)
        {
            this.subStructure = new List<IDiscEntry>();
            this.path = path;
            SetRootPath(rootPath);

            CreateStructureFromDisc();
            SetRootPath(rootPath);
        }


        /// <summary>
        /// Gets the name of the file or folder
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
        /// Creates the folder and file structure matching the one from disc.
        /// </summary>
        private void CreateStructureFromDisc()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(completePath);

                foreach (DirectoryInfo currentDirectory in info.GetDirectories())
                {
                    string newPath = String.Format("{0}{1}{2}", path, System.IO.Path.DirectorySeparatorChar, currentDirectory.Name);
                    IDiscEntry newEntry = new Folder(rootPath, newPath);

                    subStructure.Add(newEntry);
                }

                foreach (FileInfo currentFile in info.GetFiles())
                {
                    string newPath = String.Format("{0}{1}{2}", path, System.IO.Path.DirectorySeparatorChar, currentFile.Name);
                    IDiscEntry newEntry = new File(rootPath, newPath);

                    subStructure.Add(newEntry);
                }
            }

            catch (Exception ex)
            {
                throw new DiscAccessException(String.Format("{0}{1}{2}",
                                              "Could not read the content of the folder \"",
                                              completePath,
                                              "\" from disc."), ex);
            }
        }


        /// <summary>
        /// Reads the folder and file structure from disc.
        /// </summary>
        public void ReadStructureFromDisc()
        {
            foreach (IDiscEntry currentEntry in subStructure)
                currentEntry.ReadStructureFromDisc();
        }


        /// <summary>
        /// Sets the root path to the folder (or file) holding the content.
        /// </summary>
        /// <param name="rootPath">The root path to the folder (or file) holding the content</param>
        public void SetRootPath(string rootPath)
        {
            if (rootPath == string.Empty)
                throw new DiscAccessException("The folder root path cannot be empty.",
                                              new ArgumentNullException("rootPath"));

            if (rootPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) == true)
                this.rootPath = rootPath.Substring(0, rootPath.Length - 1);
            else
                this.rootPath = rootPath;

            foreach (IDiscEntry currentEntry in subStructure)
                currentEntry.SetRootPath(this.rootPath);

            this.completePath = String.Format("{0}{1}{2}", this.rootPath, System.IO.Path.DirectorySeparatorChar, path);
        }


        /// <summary>
        /// Writes the folder and file structure to disc.
        /// </summary>
        public void WriteStructureToDisc()
        {
            try
            {
                if (Directory.Exists(completePath) == false)
                    Directory.CreateDirectory(completePath);

                foreach (IDiscEntry currentEntry in subStructure)
                    currentEntry.WriteStructureToDisc();
            }

            catch (Exception ex)
            {
                throw new DiscAccessException(String.Format("{0}{1}{2}",
                                              "Could not write the content of the folder \"",
                                              completePath,
                                              "\" to disc."), ex);
            }
        }


        /// <summary>
        /// Deletes the folder and file structure from disc.
        /// </summary>
        public void DeleteStructureFromDisc()
        {
            foreach (IDiscEntry currentEntry in subStructure)
                currentEntry.DeleteStructureFromDisc();

            try
            {
                // Tests to see if we are not on a drive root
                if (completePath.LastIndexOf(System.IO.Path.DirectorySeparatorChar) > 2)
                    Directory.Delete(completePath, true);
            }
            catch (Exception) { }
        }


        /// <summary>
        /// Loads all the individual files from the folder and file structure.
        /// </summary>
        /// <param name="filesList">The list of individual files from the folder and file structure</param>
        public void BulkLoadSingleFiles(List<IDiscEntry> filesList)
        {
            foreach (IDiscEntry currentEntry in subStructure)
                currentEntry.BulkLoadSingleFiles(filesList);
        }


    }

}
