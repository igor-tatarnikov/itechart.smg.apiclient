using System;

namespace SmgApiClient.Models
{
    public class ProfileFullWS
    {
        public bool IsEnabled { get; set; }

        public int ProfileId { get; set; }

        //DepId
        public int DepartmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string FirstNameEng { get; set; }

        public string LastNameEng { get; set; }

        public string Rank { get; set; }

        public string Room { get; set; }

        public string Email { get; set; }

        //DomenName
        public string DomainName { get; set; }

        //Phone
        public string PhoneNumber { get; set; }

        //Skype
        public string SkypeNickname { get; set; }

        public DateTime Birthday { get; set; }
    }
}
