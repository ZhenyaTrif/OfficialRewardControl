using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    public partial class Command
    {
        public int CommandId { get; set; }
        public string CommandText { get; set; }

        [Column(TypeName = "date")]
        public DateTime CommandDate { get; set; }
    }
}
