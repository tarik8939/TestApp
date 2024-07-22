using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Models;

namespace TestApp.Domain.Data
{
    public class Context : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<Context>();
                OpsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = OpsBuilder.Options;
            }

            public DbContextOptionsBuilder<Context> OpsBuilder { get; set; }
            public DbContextOptions<Context> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId);


            builder.Entity<Category>()
                .HasData(new List<Category>()
                {
                    new Category{CategoryId = 1, CategoryName = "Name 1",ParentCategoryId = null},
                    new Category{CategoryId = 2, CategoryName = "Name 2",ParentCategoryId = null},
                    new Category{CategoryId = 3, CategoryName = "Name 3",ParentCategoryId = null},
                    new Category{CategoryId = 4, CategoryName = "Name 4",ParentCategoryId = null},
                    new Category{CategoryId = 5, CategoryName = "Name 5",ParentCategoryId = 1},
                    new Category{CategoryId = 6, CategoryName = "Name 6",ParentCategoryId = 2},
                    new Category{CategoryId = 7, CategoryName = "Name 7",ParentCategoryId = 3},
                    new Category{CategoryId = 8, CategoryName = "Name 8",ParentCategoryId = 4},
                    new Category{CategoryId = 9, CategoryName = "Name 9",ParentCategoryId = 5},
                    new Category{CategoryId = 10, CategoryName = "Name 10",ParentCategoryId = 8},
                    new Category{CategoryId = 11, CategoryName = "Name 11",ParentCategoryId = 9},
                    new Category{CategoryId = 12, CategoryName = "Name 12",ParentCategoryId = 11},
                    new Category{CategoryId = 13, CategoryName = "Name 13",ParentCategoryId = 12},
                    new Category{CategoryId = 14, CategoryName = "Name 14",ParentCategoryId = 5},
                    new Category{CategoryId = 15, CategoryName = "Name 15",ParentCategoryId = 6},
                    new Category{CategoryId = 16, CategoryName = "Name 16",ParentCategoryId = 7},
                });
        }

        public DbSet<Category> Categories { get; set; }
    }
}
