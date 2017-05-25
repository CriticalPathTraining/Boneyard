using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDBGenerateCustomers.Models;

namespace SqlDBGenerateCustomers {
  class Program {
    static void Main(string[] args) {


      WingtipCustomersDBEntities dbContext = new WingtipCustomersDBEntities();

      //foreach (var id in dbContext.Customers.Select(c => c.ID)) {
      //  var entity = new Customer{ ID = id };
      //  dbContext.Customers.Attach(entity);
      //  dbContext.Customers.Remove(entity);
      //}

      Console.WriteLine("Deleting existing data in Customers table...");
      string SqlCommand = "TRUNCATE TABLE Customers";

      dbContext.Database.ExecuteSqlCommand(SqlCommand);

      int NumberOfCustomers = 250;
      Console.WriteLine("Creating " + NumberOfCustomers.ToString() + " rows of sample customer data...");
      IEnumerable<Customer> customerList = CustomerFactory.GetCustomerList(NumberOfCustomers);
      
      int batchSizeMax = 100;
      int batchSize = 0;
      
      foreach (Customer customer in customerList) {
        dbContext.Customers.Add(customer);
        if (batchSize >= batchSizeMax) {
          Console.WriteLine("Saving batch of " + batchSize.ToString() + "....");
          dbContext.SaveChanges();
          batchSize = 0;
        }
        batchSize += 1;
      }
      dbContext.SaveChanges();

      Console.WriteLine();
      Console.WriteLine("The program has completed creating " + 
                        NumberOfCustomers.ToString() + 
                        " rows of sample customer data...");

      Console.WriteLine();
      Console.ReadLine();
      Console.WriteLine("Press ENTER to close this window");

    }
  }

}
