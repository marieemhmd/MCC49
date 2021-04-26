using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Context
{
    public class MyContext : DbContext
    {
        //kelas sbg perantara antara aplikasi dan db
        //membuat aplikasi ada 2 tipe:
        //1. code fisrt (buat aplikasi baru db)
        //2. buat db --> aplikasi
        public MyContext(DbContextOptions<MyContext> options) : base (options)
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
