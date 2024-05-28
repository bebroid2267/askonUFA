using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace askonUFA.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Desktop-UJ170;Database=tree_objects;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attributes>()
                .HasKey(a => new {a.objectId})
                ;
            modelBuilder.Entity<Attributes>()
        .HasOne(a => a.Object) // объект, с которым устанавливается связь
        .WithMany() // указываем, что у объекта может быть много атрибутов
        .HasForeignKey(a => a.objectId); // внешний ключ в сущности Attribute

            modelBuilder.Entity<Links>()
        .HasOne(l => l.Parent)
        .WithMany(p => p.ChildLinks)
        .HasForeignKey(l => l.ParentId)
        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Objects>().ToTable("Objects");

            modelBuilder.Entity<Links>()
        .HasOne(l => l.Child)
        .WithMany(c => c.ParentLinks)
        .HasForeignKey(l => l.ChildId)
        .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Attributes> Attributes {  get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Objects> Objects { get; set; }
    }
}
