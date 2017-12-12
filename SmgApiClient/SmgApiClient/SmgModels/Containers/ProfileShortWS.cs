namespace SmgApiClient.SmgModels.Containers
{
    public class ProfileShortWS
    {
        public int ProfileId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FirstNameEng { get; set; }

        public string LastNameEng { get; set; }

        public string Position { get; set; }

        public string Room { get; set; }

        public int DeptId { get; set; }

        public string Photo { get; set; }

        public bool IsEnabled { get; set; }
    }
}
