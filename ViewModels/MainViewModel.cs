using askonUFA.Database;
using askonUFA.Models;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore.Metadata;
using MVVM_test1.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using GalaSoft.MvvmLight.Helpers;


namespace askonUFA.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Objects CurrentObject
        {
            get { return _currentObject; }
            set
            {
                 _currentObject = value;
                OnPropertyChanged(nameof(CurrentObject));
            }
        }

        public ViewModelBase CurrentVM
        {
            get { return currentVM; }
            set
            {
                currentVM = value;
                OnPropertyChanged(nameof(currentVM));
            }
        }
        public ViewModelBase CurrentVMFromButtons
        {
            get { return currentVM; }
            set
            {
                currentVM = value;
                OnPropertyChanged(nameof(currentVM));
            }
        }
        public Attributes CurrentAttribute
        {
            get { return _currentAttribute; }
            set
            {
                _currentAttribute = value;
                OnPropertyChanged(nameof(CurrentAttribute));
            }
        }
        public object Selecteditem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(Selecteditem));
                }
            }
        }
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
            //AddObject = new MVVM_test1.Utilities.RelayCommand(ExecuteButtonCommandAttribute);
            GetObjects();
            ShowAddAttributeView = new RelayCommand<Objects>(obj =>
            {
                AddDeleteObjectViewModel objectVm = new AddDeleteObjectViewModel(obj);
                CurrentVM = objectVm;
                objectVm.ObjectsUpdated += GetObjects;
            });
            ShowAddDeleteObjectView = new RelayCommand<Objects>(obj =>
            {
                AddDeleteObjectViewModel objectVm = new AddDeleteObjectViewModel(obj);
                CurrentVM = objectVm;
                objectVm.ObjectsUpdated += GetObjects;
            });
        }
        private void GetObjects()
        {
                Objects.Clear();
                List<Objects> objects =  MethodsToDb.GetAllObjects();
                List<Attributes> attributes =  MethodsToDb.GetAllAttributes();
                foreach (var item in objects)
                {
                    item.Attributess.AddRange(attributes.Where(x => x.ObjectId == item.Id));
                }
                Objects.AddRange(objects);
        }
        //private void ExecuteButtonCommandAttribute(object parameter)
        //{

        //    if (!string.IsNullOrEmpty(_currentObject.Type) && !string.IsNullOrEmpty(_currentObject.Product))
        //    {
        //        if (parameter is Objects)
        //        {
        //            var selectedItem = parameter as Objects;

        //            if(_currentObject != selectedItem)
        //            {
        //                _objectModel.AddObject(_currentObject, selectedItem);
        //                Objects.Clear();
        //                GetObjects();
        //            }

        //        }

        //        else
        //        {
        //            _objectModel.AddObject(_currentObject);
        //            Objects.Add(_currentObject);
        //            Objects.Clear();
        //            GetObjects();
        //        }



        //        OnPropertyChanged();

        //    }
        //    else if (!string.IsNullOrEmpty(_currentAttribute.value) && !string.IsNullOrEmpty(_currentAttribute.name))
        //    {
        //        if (parameter is Objects)
        //        {
        //            var selectedItem = parameter as Objects;
        //            _objectModel.AddAttribute(_currentAttribute, selectedItem);
        //            Objects.Clear();
        //            GetObjects();
        //            OnPropertyChanged();
        //        }
        //    }
        //    else
        //        MessageBox.Show("не введены данные");
        //    _currentObject.Type = null;
        //    _currentObject.Product = null;
        //    _currentObject.ParentLinks = null;
        //    _currentObject.Id = 0;

        //    _currentAttribute.value = null;
        //    _currentAttribute.name = null;
        //    _currentAttribute.Id = 0;

        //}
        public ICommand ShowAddAttributeView { get; set; }
        public ICommand ShowAddDeleteObjectView { get; set; }
        public ICommand AddObject { get; private set; }
        private TreeObjectsModel _objectModel = new TreeObjectsModel();
        private object _selectedItem;
        private Objects _currentObject { get; set; } = new Objects ();
        private Attributes _currentAttribute = new Attributes();
        private ViewModelBase currentVM;
    }
    
}
