using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMigrator.Migrations;

namespace AutoMigrator.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext() 
        {
            Database.SetInitializer<ModelContext>(null);
        }
        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var convention = new AttributeToColumnAnnotationConvention<DefaultValueAttribute, string>(MyCodeGenerator.SqlDefaultValue, (p, attributes) => attributes.SingleOrDefault().Value.ToString());
            modelBuilder.Conventions.Add(convention);
        }
    }
}
