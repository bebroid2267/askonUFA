using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace askonUFA.Database
{
    public static class MethodsToDb
    {
        public static async Task AddObject(string type, string product)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                await context.Objects.AddAsync(new Objects()
                {
                    Type = type,
                    Product = product
                });
                await context.SaveChangesAsync();
            }
        }
        public static async Task AddAttribute(int objectId, string name, string value)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                await context.Attributes.AddAsync(new Attributes()
                {
                    Id = objectId,
                    name = name,
                    value = value
                });
                await context.SaveChangesAsync();
            }
        }
        public static async Task AddLink(int parentId, int childId)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                await context.Links.AddAsync(new Links()
                {
                    ParentId = parentId,
                    ChildId = childId
                });
                await context.SaveChangesAsync();
            }
        }
        public static List<Objects> GetAllObjects()
        {
            
            List<Objects> objects = new List<Objects>();
            using (var context = new ApplicationDbContext())
            {
                objects =  context.Objects
                    .Include(obj => obj.ChildLinks)
                        .ThenInclude(link => link.Child)
                    .Include(obj => obj.ParentLinks)
                        .ThenInclude(link => link.Parent)
                    .ToList();
            }
            
            return objects;
        }
        public static List<Attributes> GetAllAttributes()
        {
            
            List<Attributes> objects = new List<Attributes>();
            using (var context = new ApplicationDbContext())
            {
                objects =  context.Attributes.ToList();
            }

            return objects;
        }
        public static void AddAttribute(Attributes _attribute, Objects parent)
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
        public static void DeleteObject(Objects _object)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                // Удаление связанных ссылок
                var linksToRemove = context.Links.Where(y => y.ParentId == _object.Id || y.ChildId == _object.Id).ToList();
                context.Links.RemoveRange(linksToRemove);

                // Удаление связанных атрибутов
                var attributesToRemove = context.Attributes.Where(y => y.ObjectId == _object.Id).ToList();
                context.Attributes.RemoveRange(attributesToRemove);

                // Удаление самого объекта
                context.Objects.Remove(_object);

                // Сохранение изменений
                context.SaveChanges();
            }
        }

        public static void DeleteAttribute(Attributes _attribute)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Attributes.FirstOrDefault(_attribute);
                context.SaveChanges();
            }
        }

        public static void AddObject(Objects _object)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Objects.Add(_object);
                context.SaveChanges();
            }
        }

        public static void AddObject(Objects _object, Objects parent)
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
                //if (_object.Id == parent.Id)
                //{
                //    _object.Id++;

                //}

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

    }
}
