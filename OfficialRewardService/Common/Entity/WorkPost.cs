using System.Collections.Generic;

namespace Common.Entity
{
    public partial class WorkPost
    {
        public WorkPost()
        {
            Employees = new HashSet<Employee>();
            Users = new HashSet<User>();
        }

        public int WorkPostId { get; set; }
        public string WorkPostName { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
