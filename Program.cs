using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMigrator
{
    // こいつをDebugしたい時は、StartUpプロジェクトに設定して動かせばローカルで動くよ
    public class Program
    {
        // TODO:  - ただし、MSBuildを現状Local稼働させているので、以下対策が必要
        //   1. MSBuildのInstall by MSBuild installer
        //   2. 同 by JMLoggerInstaller
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("begin migration.");
                var mig = new Migrators.Migrator();
                mig.ExecuteMigrationCommand();
                Console.WriteLine("finished.");
                Console.ReadKey();
                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        // table name が複数形に勝手になる場合の対処法
        // 但し、英語以外の言語の場合辞書を作成する必要があるみたい。特に気にする必要もなさそうｗ
        // System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(new CultureInfo("en-US")).Pluralize(value);

    }
}
