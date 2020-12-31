using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MiniBank.Controllers;
using MiniBank.Models.Accounts;
using MiniBank.Models;
using MiniBank.View;

namespace MiniBank
{

    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;database=MiniBankDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

            IModelCreator modelCreator = new ModelCreator(
                new UserCreator(),
                new AccountCreator()
                );
            IDataReaderConverter dataReaderConverter = new DataReaderConverter(
                new DataReaderUserConverter(modelCreator.UserCreator),
                new DataReaderAccountConverter(modelCreator.AccountCreator));

            ISqlRunner sqlRunner = new SqlRunner(new SqlConnection(connectionString), dataReaderConverter);

            IConsoleView consoleView = new ConsoleView(new ModelPrinter());

            ConsoleController controller = new ConsoleController(
                sqlRunner,
                consoleView);

            controller.Start();



        }
    }
}

