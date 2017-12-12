using SmgApiClient.SmgModels.Containers;
using System.Collections.Generic;

namespace SmgApiClient.SmgModels.Methods
{
    internal class GetAllEmployeesResponse : BaseResponse
    {
        public GetAllEmployeesResponse()
        {
            Profiles = new List<ProfileShortWS>();
        }

        public IEnumerable<ProfileShortWS> Profiles { get; set; }
    }
}
