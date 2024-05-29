using askonUFA.Database;
using askonUFA.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using MVVM_test1.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askonUFA.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Objects> Objects
        {
            get { return _objectModel.Objects; }
            set
            {
                _objectModel.Objects = value;
                OnPropertyChanged(nameof(Objects));
            }
        }
        
        public MainViewModel()
        {
            
        }
        private async Task GetObjects()
        {
            Objects.AddRange(await MethodsToDb.GetAllObjects());
        }
        
        public static async Task<MainViewModel> CreateAsync()
        {
            var ret = new MainViewModel();
            await ret.GetObjects();
            return ret;
        }
        
        private TreeObjectsModel _objectModel = new TreeObjectsModel();
        
        
    }
}
