using Newtonsoft.Json;
using SmgApiClient.Exceptions;
using SmgApiClient.SmgModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmgApiClient
{
    internal static class RequestManager
    {
        private const string SmgApiUrl = "https://smg.itechart-group.com/MobileServiceNew/MobileService.svc";
        private const string SessionIdKeyName = "sessionId";

        private static string _apiUrl = SmgApiUrl;

        public static void SetCustomApiUrl(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public static async Task<T> Get<T>(
            int sessionId,
            string methodName,
            Dictionary<string, string> parameters = null)
            where T : BaseResponse
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }

            parameters.Add(SessionIdKeyName, sessionId.ToString());

            var requestPrefix = $"{_apiUrl}/{methodName}";
            var parameterStatements = parameters.Select(x => string.Format("{0}={1}", x.Key, WebUtility.UrlEncode(x.Value))).ToList();
            var requestParameters = string.Join('&', parameterStatements);
            var url = $"{requestPrefix}?{requestParameters}";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                using (var responseContent = response.Content)
                {
                    string data = await responseContent.ReadAsStringAsync();
                    return GetResponseModel<T>(methodName, data);
                }
            }
        }

        public static async Task<T> Post<T>(string methodName, object parameters)
            where T : BaseResponse
        {
            var requestUrl = $"{_apiUrl}/{methodName}";
            var parametersJson = JsonConvert.SerializeObject(parameters);
            var requestBody = new StringContent(parametersJson, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(requestUrl, requestBody))
                using (var responseContent = response.Content)
                {
                    string data = await responseContent.ReadAsStringAsync();
                    return GetResponseModel<T>(methodName, data);
                }
            }
        }

        private static T GetResponseModel<T>(string methodName, string responseContent)
            where T : BaseResponse
        {
            if (!string.IsNullOrEmpty(responseContent))
            {
                var result = JsonConvert.DeserializeObject<T>(responseContent);

                if (!string.IsNullOrEmpty(result.ErrorCode))
                {
                    throw new SmgApiException(result.ErrorCode, $"Unable to process request to {methodName}");
                }

                return result;
            }

            return null;
        }
    }
}
