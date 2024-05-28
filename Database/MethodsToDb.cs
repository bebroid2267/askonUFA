using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    objectId = objectId,
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
        public static async Task<List<Objects>> GetAllObjects()
        {
            using (var context = new ApplicationDbContext())
            {

                List<Objects> objects = await context.Objects
            .Include(obj => obj.Attributess)
            .Include(obj => obj.ChildLinks)
                .ThenInclude(link => link.Child)
            .Include(obj => obj.ParentLinks)
                .ThenInclude(link => link.Parent)
            .ToListAsync();
                return objects;
            }
        }


    }
}
