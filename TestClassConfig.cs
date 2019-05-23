using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp2
{
   class TestClassConfig: IEntityTypeConfiguration<TestClass>
   {
      public void Configure(EntityTypeBuilder<TestClass> builder)
      {
         builder.ToTable("TestClass");
         builder.HasIndex(t => new { t.Name }).IsUnique(true);
      }
   }
}
