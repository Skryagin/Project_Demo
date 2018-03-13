using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class FillingInSmile
    {
        public static class StringRepository
        {
            public static ObservableCollection<_Image> GetStrings()
            {
                string path = Directory.GetCurrentDirectory();
                path = Directory.GetParent(path).ToString();
                path = Directory.GetParent(path).ToString();
                string pathtmp = path;
                path = path + @"\Images\1.gif";
                string path2 = pathtmp + @"\Images\ae.gif";
                string path3 = pathtmp + @"\Images\al.gif";
                ObservableCollection<_Image> strings = new ObservableCollection<_Image>()
                {
                     new _Image { Way = path,Name= "1.gif"},
                     new _Image { Way =path2,Name= "ae.gif" },
                     new _Image { Way = path3,Name="al.gif"  }
                };
                return strings;
            }
        }
    }
}
