using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMigrator.Models
{
    public class Model : EntityBase
    {
        public Model(DateTime created) : base(created)
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Int64 ModelId { get; set; }  
    }
}
