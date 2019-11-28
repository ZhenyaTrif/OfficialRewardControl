namespace Common.Entity
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserMiddleName { get; set; }
        public int WorkPostId { get; set; }

        public WorkPost WorkPost { get; set; }
    }
}
