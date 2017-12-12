using System;

namespace SmgApiClient.Models
{
    public class SmgFullProfile : SmgShortProfile
    {
        public string Rank { get; set; }

        public string MiddleName { get; set; }

        public DateTime Birthday { get; set; }

        public string Skype { get; set; }

        public string Phone { get; set; }

        public string DomainName { get; set; }

        public string Email { get; set; }
    }
}
