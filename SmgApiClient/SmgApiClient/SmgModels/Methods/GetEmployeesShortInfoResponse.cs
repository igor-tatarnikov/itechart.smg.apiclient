using SmgApiClient.SmgModels.Containers;
using System.Collections.Generic;

namespace SmgApiClient.SmgModels.Methods
{
    internal class GetEmployeesShortInfoResponse : BaseResponse
    {
        public GetEmployeesShortInfoResponse()
        {
            Profiles = new List<ProfileExtraShortWS>();
        }

        public IEnumerable<ProfileExtraShortWS> Profiles { get; set; }
    }
}
