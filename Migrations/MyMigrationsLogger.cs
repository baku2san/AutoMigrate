using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMigrator.Migrations
{
    public class MyMigrationsLogger : MigrationsLogger
    {
        public override void Info(string message)
        {
            Console.WriteLine("Info " + message);
        }

        public override void Verbose(string message)
        {
            Console.WriteLine("Verbose" + message);
        }

        public override void Warning(string message)
        {
            Console.WriteLine("Warning" + message);
        }
    }
}
