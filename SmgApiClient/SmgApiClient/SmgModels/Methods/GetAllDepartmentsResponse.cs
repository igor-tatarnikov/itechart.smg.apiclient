using SmgApiClient.SmgModels.Containers;
using System.Collections.Generic;

namespace SmgApiClient.SmgModels.Methods
{
    internal class GetAllDepartmentsResponse : BaseResponse
    {
        public GetAllDepartmentsResponse()
        {
            Depts = new List<DepartmentWS>();
        }

        public IEnumerable<DepartmentWS> Depts { get; set; }
    }
}
