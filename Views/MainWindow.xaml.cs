using askonUFA.Database;
using askonUFA.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace askonUFA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        //private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    this.DataContext = await MainViewModel.CreateAsync();
        //}

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender is TreeView treeView)
            {
                var selectedItem = treeView.SelectedItem;
                //ButtonAd.CommandParameter = selectedItem;
                var vm = DataContext as MainViewModel;
                vm.ShowAddDeleteObjectView.Execute(selectedItem);
            }
        }
    }
}