using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTagCreator
{
    public class FolderTemplate
    {
        public DirectoryInfo _DirInfo { get; set; }
        public String  StrName { get; set; }
        public long lgSize { get; set; }
        public String  strImageLoaction { get; set; }

        public String strFullName { get; set; }
    }
}
