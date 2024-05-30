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
            AddObject = new MVVM_test1.Utilities.RelayCommand(ExecuteButtonCommandAttribute);
            GetObjects();
        }
        private void GetObjects()
        {
                List<Objects> objects =  MethodsToDb.GetAllObjects();
                List<Attributes> attributes =  MethodsToDb.GetAllAttributes();
                foreach (var item in objects)
                {
                    item.Attributess.AddRange(attributes.Where(x => x.ObjectId == item.Id));
                }
                Objects.AddRange(objects);
            
        }
        private void ExecuteButtonCommandAttribute(object parameter)
        {
            
            if (_currentObject.Type != null && _currentObject.Product != null)
            {
                if (parameter is Objects)
                {
                    var selectedItem = parameter as Objects;
                    if(_currentObject.Id == 1)
                        _currentObject.Id = 2;
                    if(_currentObject != selectedItem)
                    {
                        _objectModel.AddObject(_currentObject, selectedItem);
                        Objects.Add(_currentObject);
                    }

                }
                //else if (parameter is Attributes)
                //{
                //    var selectedItem = parameter as Attributes;
                //    _objectModel.AddAttribute(_currentObject, selectedItem);
                //}
                else
                {
                    _objectModel.AddObject(_currentObject);
                    Objects.Add(_currentObject);
                }

                OnPropertyChanged();
                
            }
            else if (_currentAttribute.value != null && _currentAttribute.name != null)
            {
                if (parameter is Objects)
                {
                    var selectedItem = parameter as Objects;
                    _objectModel.AddAttribute(_currentAttribute, selectedItem);
                    Objects.FirstOrDefault(selectedItem).Attributess.Add(_currentAttribute);
                    OnPropertyChanged();
                }
            }
            else
                MessageBox.Show("не введены данные");
        }
        //public static async Task<MainViewModel> CreateAsync()
        //{
        //    var ret = new MainViewModel();
        //    await ret.GetObjects();
        //    return ret;
        //}
        public ICommand AddObject { get; private set; }
        private TreeObjectsModel _objectModel = new TreeObjectsModel();
        private object _selectedItem;
        private Objects _currentObject = new Objects ();
        private Attributes _currentAttribute = new Attributes();
    }
    //public class TreeViewItemBehavior : Behavior<TreeView>
    //{
    //    public static readonly DependencyProperty SelectedItemProperty =
    //        DependencyProperty.Register("SelectedItem",
    //                                    typeof(object),
    //                                    typeof(TreeViewItemBehavior),
    //                                    new FrameworkPropertyMetadata(null,
    //                                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
    //                                        OnSelectedItemChanged));

    //    public object SelectedItem
    //    {
    //        get { return GetValue(SelectedItemProperty); }
    //        set { SetValue(SelectedItemProperty, value); }
    //    }

    //    private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        var behavior = d as TreeViewItemBehavior;
    //        if (behavior != null && behavior.AssociatedObject != null)
    //        {
    //            var treeView = behavior.AssociatedObject;
    //            treeView.SelectedItemChanged -= behavior.AssociatedObject_SelectItemChanged;

    //            var treeViewItem = treeView.ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
    //            if (treeViewItem != null)
    //            {
    //                treeViewItem.IsSelected = true;
    //            }

    //            treeView.SelectedItemChanged += behavior.AssociatedObject_SelectItemChanged;
    //        }
    //    }

    //    protected override void OnAttached()
    //    {
    //        base.OnAttached();
    //        AssociatedObject.SelectedItemChanged += AssociatedObject_SelectItemChanged;
    //    }

    //    protected override void OnDetaching()
    //    {
    //        base.OnDetaching();
    //        if (AssociatedObject != null)
    //        {
    //            AssociatedObject.SelectedItemChanged -= AssociatedObject_SelectItemChanged;
    //        }
    //    }

    //    private void AssociatedObject_SelectItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    //    {
    //        SelectedItem = e.NewValue;
    //    }
    //}
}
