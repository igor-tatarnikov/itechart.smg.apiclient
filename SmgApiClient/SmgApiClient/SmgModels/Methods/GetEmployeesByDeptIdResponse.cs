using SmgApiClient.SmgModels.Containers;
using System.Collections.Generic;

namespace SmgApiClient.SmgModels.Methods
{
    internal class GetEmployeesByDeptIdResponse : BaseResponse
    {
        public GetEmployeesByDeptIdResponse()
        {
            Profiles = new List<ProfileShortWS>();
        }

        public IEnumerable<ProfileShortWS> Profiles { get; set; }
    }
}
