using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2
{
   class Program
   {
      static void Main(string[] args)
      {
         
         TestClassTest t = new TestClassTest();

         t.BaseServiceTestInitialize(true);
         t.TestInitialize(true);
         t.TestSomething(true).Wait();

         t = new TestClassTest();

         t.BaseServiceTestInitialize(false);
         t.TestInitialize(false);
         t.TestSomething(false).Wait();

         Console.ReadLine();
      }
   }
}
