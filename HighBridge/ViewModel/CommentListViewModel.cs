using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighBridge.Common.Util;

namespace HighBridge.ViewModel
{
    class CommentListViewModel:ViewModelBase
    {
        private readonly ObservableCollection<CommentUnitViewModel> _itemsCollection;

        public CommentListViewModel()
        {
            _itemsCollection=new ObservableCollection<CommentUnitViewModel>();
            ItemsCollection.Add(new CommentUnitViewModel(null,"星野","こんにちは"));
            ItemsCollection.Add(new CommentUnitViewModel(null,"oh","tes"));
            ItemsCollection.Add(new CommentUnitViewModel(null,"小野寺","yayaya"));
            ItemsCollection.Add(new CommentUnitViewModel(null,"高橋","hahaha"));
            ItemsCollection.Add(new CommentUnitViewModel(null, "中野", "hahaha"));
            ItemsCollection.Add(new CommentUnitViewModel(null, "中野", "hahahhsshsssa"));
            OnpropertyChanged();
        }

        public ObservableCollection<CommentUnitViewModel> ItemsCollection
        {
            get { return _itemsCollection; }
        }
    }
}
