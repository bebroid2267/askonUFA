using askonUFA.Database;
using askonUFA.Models;
using GalaSoft.MvvmLight.Command;
using MVVM_test1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace askonUFA.ViewModels
{
    public class AddDeleteObjectViewModel : ViewModelBase
    {
        private Objects _newObject = new Objects();
        public Objects NewObject
        {
            get { return _newObject; }
            set
            {
                _newObject = value;
                OnPropertyChanged(nameof(NewObject));
            }
        }

        

        
        public delegate void ObjectsUpdatedHandler();
        public event ObjectsUpdatedHandler ObjectsUpdated;

        public AddDeleteObjectViewModel(Objects selectedObject)
        {
            AddObjectCommand = new MVVM_test1.Utilities.RelayCommand(AddObject);
            DeleteObjectCommand = new MVVM_test1.Utilities.RelayCommand(DeleteObject);
            _selectedObjects = selectedObject;
            

        }
        
        private void AddObject(object parameter)
        {
            parameter = _selectedObjects;
            if (!string.IsNullOrEmpty(_currentObject.Type) && !string.IsNullOrEmpty(_currentObject.Product))
            {
                if (parameter is Objects)
                {
                    var selectedItem = parameter as Objects;

                    if (_currentObject != selectedItem)
                    {
                        MethodsToDb.AddObject(_currentObject, selectedItem);
                        ObjectsUpdated?.Invoke();
                    }
                }
            }
            else
                MessageBox.Show("Некорректный ввод");
            _currentObject.Type = null;
            _currentObject.Product = null;
            _currentObject.ParentLinks = null;
            _currentObject.Id = 0;
        }
        private void DeleteObject(object parameter)
        {
            if (parameter != null)
            {
                var selectedItem = parameter as Objects;
                MethodsToDb.DeleteObject(_selectedObjects);
                ObjectsUpdated?.Invoke();

            }
            else
                MessageBox.Show("Ошибка");
        }

        public Objects CurrentObject
        {
            get { return _currentObject; }
            set
            {
                _currentObject = value;
                OnPropertyChanged(nameof(CurrentObject));
            }
        }
        public ICommand DeleteObjectCommand { get; private set; }
        public ICommand AddObjectCommand { get; private set; }
        private Objects _selectedObjects {  get; set; }
        private Objects _currentObject { get; set; } = new Objects();
        private TreeObjectsModel _objectModel = new TreeObjectsModel();


    }
}
