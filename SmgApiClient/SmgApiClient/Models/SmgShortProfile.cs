namespace SmgApiClient.Models
{
    public class SmgShortProfile
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FirstNameEng { get; set; }

        public string LastNameEng { get; set; }

        public string Position { get; set; }

        public string Room { get; set; }

        public int DepartmentId { get; set; }

        public string PhotoUrl { get; set; }

        public bool IsEnabled { get; set; }
    }
}
