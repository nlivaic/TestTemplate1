using System;
using System.IO;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestTemplate1.Migrations
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var connectionString = string.Empty;
            var dbUser = string.Empty;
            var dbPassword = string.Empty;

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Development";
            Console.WriteLine($"Environment: {env}.");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            InitializeParameters();
            Console.WriteLine($"connectionString: {connectionString}.");
            Console.WriteLine($"dbUser: {dbUser}.");
            Console.WriteLine($"dbPassword: {dbPassword}.");
            var connectionStringTestTemplate1 = new SqlConnectionStringBuilder(connectionString)
            {
                UserID = dbUser,
                Password = dbPassword
            }.ConnectionString;
            Console.WriteLine($"connectionStringTestTemplate1: {connectionStringTestTemplate1}.");

            string scriptsPath = null;
            if (args.Length == 3)
            {
                scriptsPath = args[2];
            }

            var upgraderTestTemplate1 =
                DeployChanges.To
                    .SqlDatabase(connectionStringTestTemplate1)
                    .WithScriptsFromFileSystem(
                        !string.IsNullOrWhiteSpace(scriptsPath)
                                ? Path.Combine(scriptsPath, "TestTemplate1Scripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate1Scripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate1.");
            var resultTestTemplate1 = upgraderTestTemplate1.PerformUpgrade();

            if (!resultTestTemplate1.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate1 upgrade error: {resultTestTemplate1.Error}");
                Console.ResetColor();
                return -1;
            }

            // Uncomment the below sections if you also have an Identity Server project in the solution.
            /*
            var connectionStringTestTemplate1Identity = string.IsNullOrWhiteSpace(args.FirstOrDefault())
                ? config["ConnectionStrings:TestTemplate1IdentityDb"]
                : args.FirstOrDefault();

            var upgraderTestTemplate1Identity =
                DeployChanges.To
                    .SqlDatabase(connectionStringTestTemplate1Identity)
                    .WithScriptsFromFileSystem(
                        scriptsPath != null
                            ? Path.Combine(scriptsPath, "TestTemplate1IdentityScripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate1IdentityScripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate1 Identity.");
            if (env != "Development")
            {
                upgraderTestTemplate1Identity.MarkAsExecuted("0004_InitialData.sql");
                Console.WriteLine($"Skipping 0004_InitialData.sql since we are not in Development environment.");
                upgraderTestTemplate1Identity.MarkAsExecuted("0005_Initial_Configuration_Data.sql");
                Console.WriteLine($"Skipping 0005_Initial_Configuration_Data.sql since we are not in Development environment.");
            }
            var resultTestTemplate1Identity = upgraderTestTemplate1Identity.PerformUpgrade();

            if (!resultTestTemplate1Identity.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate1 Identity upgrade error: {resultTestTemplate1Identity.Error}");
                Console.ResetColor();
                return -1;
            }
            */

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;

            void InitializeParameters()
            {
                if (args.Length == 0)
                {
                    connectionString = config["ConnectionStrings:TestTemplate1Db_Migrations_Connection"];
                    dbUser = config["DB_USER"];
                    dbPassword = config["DB_PASSWORD"];
                }
                else if (args.Length == 3)
                {
                    connectionString = args[0];
                    dbUser = args[1];
                    dbPassword = args[2];
                }
            }
        }
    }
}
