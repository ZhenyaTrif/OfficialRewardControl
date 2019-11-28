using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    public partial class BuisenessBook
    {
        public BuisenessBook()
        {
            PrivateBusinesses = new HashSet<PrivateBusiness>();
        }

        public int BuisenessBookId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatingDate { get; set; }

        public ICollection<PrivateBusiness> PrivateBusinesses { get; set; }
    }
}
