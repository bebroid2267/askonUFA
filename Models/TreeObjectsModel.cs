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
        public void AddAttribute(Attributes _attribute, Objects parent)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (_attribute.Id == 0) // Если это новый атрибут
                {
                    // Устанавливаем внешний ключ на родительский объект
                    _attribute.ObjectId = parent.Id; // Здесь предполагается, что у атрибута есть свойство ObjectId
                    parent.Attributess.Add(_attribute);
                    // Добавляем атрибут в контекст и сохраняем изменения
                    context.Attributes.Add(_attribute);
                    context.SaveChanges();
                }
                else // Если это обновление существующего атрибута
                {
                    // Обновляем атрибут в контексте и сохраняем изменения
                    context.Attributes.Update(_attribute);
                    context.SaveChanges();
                }
            }
        }


        public void AddObject(Objects _object)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Objects.Add(_object);
                context.SaveChanges();
            }
        }

        public void AddObject(Objects _object, Objects parent)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                // Нельзя задавать Id для новых объектов вручную, если это поле Identity.
                //if (_object.Id != 0)
                //{
                //    throw new InvalidOperationException("ID for new objects should not be set manually when using IDENTITY column.");
                //}

                // Добавляем _object в контекст.
                
                context.Objects.Add(_object);
                if (_object.Id == parent.Id)
                {
                    _object.Id++;

                }

                // Сохраняем _object, чтобы EF сгенерировал и назначил Id.
                context.SaveChanges();
                
                // Теперь, когда у _object есть Id, добавляем новую связь в context.Links.
                context.Links.Add(new Links()
                {
                    ChildId = _object.Id, // _object.Id сгенерирован и назначен после первого SaveChanges
                    ParentId = parent.Id // Убедитесь, что ParentId существует в базе данных
                });

                // Сохраняем изменения, включая новую связь.
                context.SaveChanges();

                // Теперь _object и соответствующий ему Links сохранены и имеют корректные ID.
            }
        }



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
