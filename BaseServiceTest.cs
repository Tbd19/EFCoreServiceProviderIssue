using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
   public abstract class BaseServiceTest : BaseTest
   {
      protected TestContext Context { get; private set; }

      public void BaseServiceTestInitialize(bool withServiceProvider)
      {
         Context = GetTestingDatabaseContext(withServiceProvider);
      }

      public void TestCleanup()
      {
         Context.Dispose();
      }

      protected async Task RunAsyncTest(Action<TestContext> testSetup, Func<Task> test, bool withServiceProvider)
      {
         // create context
         using (var testDatabaseContext = GetTestingDatabaseContext(withServiceProvider))
         {
            // invoke testSetup
            await Task.Run(() => testSetup.Invoke(testDatabaseContext)).ConfigureAwait(false);

            await test.Invoke().ConfigureAwait(false);
         }
      }
   }
}
