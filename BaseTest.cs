using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2
{
   public abstract class BaseTest
   {
      protected virtual TestContext GetTestingDatabaseContext(bool withServiceProvider)
      {
         DbContextOptions<TestContext> options;

         if(withServiceProvider)
         {
            var serviceProvider = new ServiceCollection()
               .AddEntityFrameworkInMemoryDatabase()
               ////.AddSingleton(typeof(IDeviceAuditTrailService), AuditTrailService)
               .BuildServiceProvider();

            options = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .UseInternalServiceProvider(serviceProvider)
                .Options;
         }
         else
         {
            options = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
         }
            // Run the test against one instance of the context
            return new TestContext(options);
      }
   }
}
