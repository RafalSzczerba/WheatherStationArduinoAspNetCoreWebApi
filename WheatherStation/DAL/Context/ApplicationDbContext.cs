using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WheatherStation.DAL.Entities;

namespace WheatherStation.DAL.Context
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected readonly IConfiguration Configuration;
        Microsoft.EntityFrameworkCore.DbSet<Arduino> Arudino { get; set; }
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
