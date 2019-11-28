namespace Common.Entity
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public int WorkPostId { get; set; }
        public int RegionId { get; set; }
        public int PrivateBusinessId { get; set; }
        public int SubdivisionId { get; set; }

        public PrivateBusiness PrivateBusiness { get; set; }
        public Region Region { get; set; }
        public Subdivision Subdivision { get; set; }
        public WorkPost WorkPost { get; set; }
    }
}
