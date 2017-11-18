using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMigrator.Models
{
    public class EntityBase
    {
        // コード側の生成時刻
        public DateTime Created { get; set; }

        // DB側での挿入時刻
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), DefaultValue("GETDATE()")]
        public DateTime Inserted { get; set; }

        public EntityBase(DateTime? created = null) : base()
        {
            Created = created ?? DateTime.Now;  // 実際には、このコンストラクタが使われる機会はないんだけどね・・一応・・
        }
    }
}
