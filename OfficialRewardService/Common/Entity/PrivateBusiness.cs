using System;
using System.Collections.Generic;

namespace Common.Entity
{
    public partial class PrivateBusiness
    {
        public PrivateBusiness()
        {
            Employees = new HashSet<Employee>();
        }

        public int PrivateBusinessId { get; set; }
        public string Autobiography { get; set; }
        public int? BuisenessBookId { get; set; }

        public BuisenessBook BuisenessBook { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
