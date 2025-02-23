using PhotoCaptureApplication.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PhotoCaptureApplication.DAL
{
    public partial class PhotoCaptureDataContext : DbContext
    {
        private IConfiguration configuration;

        public PhotoCaptureDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PhotoModel> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
