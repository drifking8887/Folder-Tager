using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTagCreator
{
    public class TagCreator
    {
        public static bool CreateIconedFolder(string folderName, string iconFile)
        {
            UndoIconedFolder(folderName);
            return CreateIconedFolder(folderName, iconFile, 0, "", false, true);
        }

        private static bool CreateIconedFolder(string folderName, string iconFile, int iconIndex, string toolTip, bool preventSharing, bool confirmDelete)
        {
            #region Private Variables
            DirectoryInfo folder;
            string fileName = "desktop.ini";
            #endregion Private Variables

            #region Data Validation

            if (Directory.Exists(folderName) == false)
            {
                return false;
            }

            #endregion Data Validation

            try
            {
                folder = new DirectoryInfo(folderName);
                fileName = Path.Combine(folderName, fileName);

                // Create the file
                //using (StreamWriter sw = new StreamWriter(fileName))
                //{
                //    sw.WriteLine("[.ShellClassInfo]");
                //    sw.WriteLine("ConfirmFileOp={0}", confirmDelete);
                //    sw.WriteLine("NoSharing={0}", preventSharing);
                //    sw.WriteLine("IconFile={0}", iconFile);
                //    sw.WriteLine("IconIndex={0}", iconIndex);
                //    sw.WriteLine("InfoTip={0}", toolTip);
                //    sw.Close();
                //}


                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("[ViewState]");
                    sw.WriteLine("Mode={0}", "");
                    sw.WriteLine("Vid={0}", "");
                    sw.WriteLine("FolderType=Generic");
                    sw.WriteLine("Logo={0}", iconFile);
                    sw.Close();
                }

                // Update the folder attributes
                //folder.Attributes = folder.Attributes | FileAttributes.System;
                //File.SetAttributes(folderName, File.GetAttributes
                         //(folderName) | FileAttributes.System);

                // "Hide" the desktop.ini
                //File.SetAttributes(fileName, File.GetAttributes(fileName) | FileAttributes.Hidden);


                // Set ini file attribute to "Hidden"
                if ((File.GetAttributes(fileName) & FileAttributes.Hidden)
                       != FileAttributes.Hidden)
                {
                    File.SetAttributes(fileName, File.GetAttributes(fileName)
                                       | FileAttributes.Hidden);
                }

                // Set ini file attribute to "System"
                if ((File.GetAttributes(fileName) & FileAttributes.System)
                       != FileAttributes.System)
                {
                    File.SetAttributes(fileName, File.GetAttributes(fileName)
                                        | FileAttributes.System);
                }



                // Set folder attribute to "System"
                if ((File.GetAttributes(folderName) & FileAttributes.System)
                       != FileAttributes.System)
                {
                    File.SetAttributes(folderName, File.GetAttributes
                                      (folderName) | FileAttributes.System);
                }

            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool UndoIconedFolder(string folderName)
        {
            #region Private Variables
            DirectoryInfo folder;
            #endregion Private Variables

            #region Data Validation
            if (Directory.Exists(folderName) == false)
            {
                return false;
            }
            #endregion Data Validation

            try
            {
                folder = new DirectoryInfo(folderName);

                // Remove the file [Desktop.ini]
                FileInfo file = new FileInfo(Path.Combine(folderName, "desktop.ini"));
                if (file.Exists)
                {
                    file.Delete();
                }
                File.SetAttributes(folderName, File.GetAttributes(folderName) & ~FileAttributes.System);
                //folder.Attributes = (folder.Attributes | FileAttributes.System);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool FileCopy(string folderName, string iconFile,bool replace=false)
        {
            try
            {
                String _DesPath = Properties.Settings.Default.DefaultImage;
                _DesPath = Path.Combine(folderName, _DesPath);
                File.Copy(iconFile, _DesPath, replace);
            }
            catch
            {
                return false;
            }
            return true;

        }
    }
}
