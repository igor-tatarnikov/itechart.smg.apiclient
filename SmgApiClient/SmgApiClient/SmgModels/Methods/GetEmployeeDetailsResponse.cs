using SmgApiClient.SmgModels.Containers;

namespace SmgApiClient.SmgModels.Methods
{
    internal class GetEmployeeDetailsResponse : BaseResponse
    {
        public ProfileFullWS Profile { get; set; }
    }
}
