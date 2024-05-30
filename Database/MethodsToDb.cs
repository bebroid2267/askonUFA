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

    }
}
