using Data.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class JUGContext:DbContext
    {
        public DbSet<TeamDAO> Teams { get; set; }
        public string ConnectionString { get; set; }

        public JUGContext(string connectionString):base()
        {
            ConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
