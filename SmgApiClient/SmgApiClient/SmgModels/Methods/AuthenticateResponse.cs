namespace SmgApiClient.SmgModels.Methods
{
    internal class AuthenticateResponse : BaseResponse
    {
        public string Permission { get; set; }

        public int SessionId { get; set; }
    }
}
