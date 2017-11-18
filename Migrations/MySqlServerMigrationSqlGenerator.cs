using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace AutoMigrator.Migrations
{
    public class MySqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetDefaultValueSql(addColumnOperation.Column);
            base.Generate(addColumnOperation);
        }

        protected override void Generate(AlterColumnOperation alterColumnOperation)
        {
            SetDefaultValueSql(alterColumnOperation.Column);
            base.Generate(alterColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetAnnotatedColumns(createTableOperation.Columns);
            base.Generate(createTableOperation);
        }

        protected override void Generate(AlterTableOperation alterTableOperation)
        {
            SetAnnotatedColumns(alterTableOperation.Columns);
            base.Generate(alterTableOperation);
        }

        private void SetDefaultValueSql(ColumnModel column)
        {
            if (column.Annotations.TryGetValue(MyCodeGenerator.SqlDefaultValue, out AnnotationValues values))
            {
                column.DefaultValueSql = values?.NewValue as string;
                column.Annotations.Remove(MyCodeGenerator.SqlDefaultValue);
            }
        }

        private void SetAnnotatedColumns(IEnumerable<ColumnModel> columns)
        {
            columns.ToList().ForEach(f => SetDefaultValueSql(f));
        }
    }
}
