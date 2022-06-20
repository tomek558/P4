using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = zad4; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }

    public static class UpsertEntity
    {
        public static void Upsert(this DbSet<Book> dbSet, Book @new)
        {
            var existing = dbSet.AsNoTracking().FirstOrDefault(inDb => inDb.Id == @new.Id);
            if (existing is null) dbSet.Add(@new);
            else dbSet.Update(@new);
        }

        public static void Upsert(this DbSet<Author> dbSet, Author @new)
        {
            //AsNoTracking jest po to żeby EF nie śledziło obiektu pobieranego do sprawdzenia czy encja istnieje
            var existing = dbSet.AsNoTracking().FirstOrDefault(inDb => inDb.Id == @new.Id);
            if (existing is null) dbSet.Add(@new);
            else dbSet.Update(@new);
        }
    }
}