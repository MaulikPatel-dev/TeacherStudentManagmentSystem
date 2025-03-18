using FluentMigrator.Runner;
using System.Reflection;

namespace TSMS.Web.DataBase
{
    public static class MigratorRunner
    {
        public static void MigrateDB(string conString, Assembly assembly)
        {
            IServiceProvider serviceProvider = CreateServices(conString, assembly);

            using IServiceScope scope = serviceProvider.CreateScope();
            UpdateDatabase(scope.ServiceProvider);
        }
        private static IServiceProvider CreateServices(string conString, Assembly assembly)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner
                (rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(conString)
                .ScanIn(assembly).For.Migrations()
                )
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            IMigrationRunner runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }


}
