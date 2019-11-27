using System;
using System.Collections.Generic;

namespace Common.Entity
{
    public partial class Region
    {
        public Region()
        {
            Employees = new HashSet<Employee>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
