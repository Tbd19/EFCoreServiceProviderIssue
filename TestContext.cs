using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
   public class TestContext: DbContext
   {
      public TestContext(DbContextOptions<TestContext> options)
          : base(options)
      {
      }

      public DbSet<TestClass> TestClasses { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.ApplyConfiguration(new TestClassConfig());
      }
   }
}
