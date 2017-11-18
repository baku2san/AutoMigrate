using AutoMigrator.Migrations;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;

namespace AutoMigrator.Migrators
{
    public class Migrator
    {
        public void ExecuteMigrationCommand()
        {
            var config = new Configuration();
            var migrator = new DbMigrator(config);
            var decorator = new MigratorLoggingDecorator(migrator, new MyMigrationsLogger());
            decorator.Update();
        }

        // And what if you want to completely trash the DB, undo all migrations, delete everything, and start over?
        private void CompletelyTrashDb()
        {
            DbMigrator migrator = new DbMigrator(new Configuration());
            migrator.Update("0");
        }
    }
}
