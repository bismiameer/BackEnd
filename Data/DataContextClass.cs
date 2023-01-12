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
        public DbSet<Uploads> uploads { get; set; }

    }
}
