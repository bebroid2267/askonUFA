using askonUFA.Database;
using askonUFA.Models;
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
    public class AddDeleteAttributeViewModel : ViewModelBase
    {
        private Attributes _newAttribute = new Attributes();
        public Attributes NewObject
        {
            get { return _newAttribute; }
            set
            {
                _newAttribute = value;
                OnPropertyChanged(nameof(NewObject));
            }
        }




        public delegate void AttributesUpdatedHandler();
        public event AttributesUpdatedHandler AttributeUpdated;

        public AddDeleteAttributeViewModel(Objects selectedObject)
        {
            AddObjectAttribute = new MVVM_test1.Utilities.RelayCommand(AddAttribute);
            _selectedObject = selectedObject;
        }

        private void AddAttribute(object parameter)
        {
            parameter = _selectedObject;
            if (!string.IsNullOrEmpty(_currentAttribute.value) && !string.IsNullOrEmpty(_currentAttribute.name))
            {
                if (parameter is Objects)
                {
                    var selectedItem = parameter as Objects;

                        MethodsToDb.AddAttribute(_currentAttribute, selectedItem);
                        AttributeUpdated?.Invoke();                    
                }
            }
            else
                MessageBox.Show("Некорректный ввод");
            _currentAttribute.value = null;
            _currentAttribute.name = null;
            _currentAttribute.Object = null;
            _currentAttribute.Id = 0;
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
        public ICommand DeleteObjectAttribute { get; private set; }
        public ICommand AddObjectAttribute { get; private set; }
        private Objects _selectedObject { get; set; }
        private Attributes _currentAttribute { get; set; } = new Attributes();
        private TreeObjectsModel _objectModel = new TreeObjectsModel();

    }
}
