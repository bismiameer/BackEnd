using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class DataContextClass:DbContext
    {
        public DataContextClass(DbContextOptions<DataContextClass> options) : base(options)
        {

        }
        public DbSet<Registration> tblregistration { get; set; }
        public DbSet<Complaints> tblcomplaints { get; set; }
        public DbSet<Category> tblcategory { get; set; }
        public DbSet<Desc> tbldesc { get; set; }
        public DbSet<Country> tblcountry { get; set; }

    }
}
