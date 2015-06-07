using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using HighBridge.Common.Util;

namespace HighBridge.ViewModel
{
    class CommentUnitViewModel:ViewModelBase
    {
        public CommentUnitViewModel()
        {
            
        }
        public CommentUnitViewModel(BitmapFrame img,string name,string comment)
        {
            Image = img;
            Name = name;
            Comment = comment;
        }
        public BitmapFrame Image { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }


    class CommentUnitViewModelIndesign:CommentUnitViewModel
    {
        public CommentUnitViewModelIndesign()
        {
            Name = "はななん";
            Comment = "もうマジ無理\nリスカしよ";
        }
    }
}
