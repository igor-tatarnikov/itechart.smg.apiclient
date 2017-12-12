using System;

namespace SmgApiClient.SmgModels.Containers
{
    public class ProfileFullWS
    {
        public int ProfileId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FirstNameEng { get; set; }

        public string LastNameEng { get; set; }

        public string Rank { get; set; }

        public string Room { get; set; }

        public int DeptId { get; set; }

        public string Image { get; set; }

        public bool IsEnabled { get; set; }

        public string MiddleName { get; set; }

        public DateTime Birthday { get; set; }

        public string Skype { get; set; }

        public string Phone { get; set; }

        public string DomenName { get; set; }

        public string Email { get; set; }
    }
}
