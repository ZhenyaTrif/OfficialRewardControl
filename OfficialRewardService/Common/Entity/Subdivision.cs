using System.Collections.Generic;

namespace Common.Entity
{
    public partial class Subdivision
    {
        public Subdivision()
        {
            Employees = new HashSet<Employee>();
        }

        public int SubdivisionId { get; set; }
        public string SubdivisionName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
