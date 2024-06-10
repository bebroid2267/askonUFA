using askonUFA.Database;
using Microsoft.IdentityModel.Tokens;
using MVVM_test1.Utilities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //public void AddObject(Objects _object, Attributes attribute)
        //{
        //    using (ApplicationDbContext context = new ApplicationDbContext())
        //    {
        //         context.Objects.Add(_object);
        //         context.Links.Add(new Links() 
        //        {
        //            ChildId = _object.Id,
        //            ParentId = attribute.Id
        //        });
        //         context.SaveChanges();
        //    }
        //}
        



        public void GetObjects()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                List<Objects> objects = MethodsToDb.GetAllObjects();
                List<Attributes> attributes = MethodsToDb.GetAllAttributes();
                foreach (var item in objects)
                {
                    item.Attributess.AddRange(attributes.Where(x => x.ObjectId == item.Id));
                }
                Objects.AddRange(objects);
            });
            

        }
        private ObservableCollection<Objects> _objects = new ObservableCollection<Objects>();
    }
}
