using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
   public class TestClassTest: BaseServiceTest
   {
      TestContext testDatabaseContext;

      public void TestInitialize(bool withServiceProvider)
      {
         testDatabaseContext = GetTestingDatabaseContext(withServiceProvider);
      }

      public async Task TestSomething(bool withServiceProvider)
      {
         await RunAsyncTest(
             db =>
             {
                var testClass = new TestClass()
                {
                   Name = "abc"
                };
                db.TestClasses.Add(testClass);

                db.SaveChanges();
             },
             async () =>
             {
                int count = await testDatabaseContext.TestClasses.CountAsync().ConfigureAwait(false);
                if (withServiceProvider)
                {
                  Console.WriteLine("The count with Service Provider is = " + count);
                }
                else
                {
                   Console.WriteLine("The count without Service Provider is = " + count);
                }
             },
             withServiceProvider).ConfigureAwait(false);
      }
   }
}
