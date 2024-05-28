using askonUFA.Database;
using MVVM_test1.Utilities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askonUFA.Models
{
    public class TreeObjectsModel : ViewModelBase
    {
        public ObservableCollection<Objects> Objects 
        {
            get { return _objects; }
            set
            {
                _objects = value;
                OnPropertyChanged(nameof(_objects));
            }
        }
        public async Task GetObjects()
        {
            Objects.AddRange(await MethodsToDb.GetAllObjects());
        }
        private ObservableCollection<Objects> _objects = new ObservableCollection<Objects>();
    }
}
