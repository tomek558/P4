using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Projekt1; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }

    public static class UpsertEntity
    {

        public static void Upsert(this DbSet<Person> dbSet, Person @new)
        {
            //AsNoTracking jest po to żeby EF nie śledziło obiektu pobieranego do sprawdzenia czy encja istnieje
            var existing = dbSet.AsNoTracking().FirstOrDefault(inDb => inDb.Id == @new.Id);
            if (existing is null) dbSet.Add(@new);
            else dbSet.Update(@new);
        }
        public static void Upsert(this DbSet<Income> dbSet, Income @new)
        {
            var existing = dbSet.AsNoTracking().FirstOrDefault(inDb => inDb.Id == @new.Id);
            if (existing is null) dbSet.Add(@new);
            else dbSet.Update(@new);
        }

        public static void Upsert(this DbSet<Outcome> dbSet, Outcome @new)
        {
            //AsNoTracking jest po to żeby EF nie śledziło obiektu pobieranego do sprawdzenia czy encja istnieje
            var existing = dbSet.AsNoTracking().FirstOrDefault(inDb => inDb.Id == @new.Id);
            if (existing is null) dbSet.Add(@new);
            else dbSet.Update(@new);
        }
    }
}