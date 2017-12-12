using SmgApiClient.SmgModels.Methods;
using System.Threading.Tasks;

namespace SmgApiClient
{
    internal class SessionManager
    {
        private const string AuthenticateMethodName = "PostAuthenticate";

        private readonly string _login;
        private readonly string _password;

        private int _sessionId;

        public SessionManager(
            string login,
            string password)
        {
            _login = login;
            _password = password;
        }

        public async Task<int> GetSessionId()
        {
            if (_sessionId == 0)
            {
                var parameters = new
                {
                    Username = _login,
                    Password = _password
                };

                var authenticateResponse = await RequestManager.Post<AuthenticateResponse>(
                    AuthenticateMethodName,
                    parameters);

                if (authenticateResponse != null)
                {
                    _sessionId = authenticateResponse.SessionId;
                }
            }

            return _sessionId;
        }
    }
}
