using Data.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Data
{
    public class JUGContext:DbContext
    {
        public DbSet<TeamDAO> Teams { get; set; }
        public DbSet<GameDAO> Games { get; set; }
        public string ConnectionString { get; set; }

        public JUGContext():base()
        {
            var settings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("databasesettings.json")
                .AddEnvironmentVariables().Build();

            var settingsToUse = settings["DatabaseToUse"];
            var connectionStringFormatter = "ConnectionStrings:{0}:ConnectionString";
            var connectionString = settings[string.Format(connectionStringFormatter, settingsToUse)];

            ConnectionString = connectionString;

        }
        public JUGContext(string connectionString):base()
        {
            ConnectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(ConnectionString);
        }

        public void DeleteData()
        {
            Games.RemoveRange(Games);
            Teams.RemoveRange(Teams);            
            SaveChanges();
        }
    }
}
