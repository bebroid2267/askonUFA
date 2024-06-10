using askonUFA.Database;
using MVVM_test1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace askonUFA.Views
{
    public class DeleteAttributeViewModel : ViewModelBase
    {
        public DeleteAttributeViewModel(Attributes attributes)
        {
            DeleteObjectAttribute = new MVVM_test1.Utilities.RelayCommand(DeleteObject);
            _selectedAttribute = attributes;

        }
        private void DeleteObject(object parameter)
        {
            if (parameter != null)
            {
                var selectedItem = parameter as Objects;
                MethodsToDb.DeleteAttribute(_selectedAttribute);
                AttributeUpdated?.Invoke();
            }
            else
                MessageBox.Show("Ошибка");
        }
        public ICommand DeleteObjectAttribute { get; private set; }
        private Attributes _selectedAttribute { get; set; }
        public delegate void AttributesUpdatedHandler();
        public event AttributesUpdatedHandler AttributeUpdated;
    }
}
