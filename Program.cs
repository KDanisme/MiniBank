using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBank.Views;
using System.Data;
using System.Data.SqlClient;
using MiniBank.Controllers;
using MiniBank.Models.Accounts;
using MiniBank.Models;

namespace MiniBank
{

    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;database=MiniBankDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

            IModelCreator modelCreator = new ModelCreator(
                new UserCreator(),
                new AccountCreator(),
                new TextItemCreator(),
                new ListHandlerCreator()
                );
            IDataReaderConverter dataReaderConverter = new DataReaderConverter(
                new DataReaderUserConverter(modelCreator.UserCreator),
                new DataReaderAccountConverter(modelCreator.AccountCreator));


            IController controller = new ConsoleController(
                new SqlConnection(connectionString),
                new ConsoleView(),
                modelCreator,
                dataReaderConverter);

            controller.Start();

        }
    }
}

