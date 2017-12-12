using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmgApiClient.Interfaces;
using SmgApiClient.Models;
using SmgApiClient.SmgModels;
using SmgApiClient.SmgModels.Methods;

namespace SmgApiClient
{
    public class HttpSmgApiClient : ISmgApiClient
    {
        #region Fields

        private readonly SessionManager _sessionManager;

        #endregion

        #region Constructor

        public HttpSmgApiClient(
            string login,
            string password)
        {
            _sessionManager = new SessionManager(login, password);
        }

        #endregion

        #region ISmgApiClient Implementation

        public async Task<IEnumerable<SmgDepartment>> GetAllDepartmentsAsync()
        {
            var response = await Get<GetAllDepartmentsResponse>("GetAllDepartments");

            if (response == null || response.Depts == null)
            {
                return null;
            }

            return response.Depts.Select(x => MappingManager.Map(x)).ToList();
        }

        public async Task<IEnumerable<SmgDepartment>> GetAllDepartmentsUpdatedAsync(DateTime startDate)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("updatedDate", startDate.ToShortDateString());

            var response = await Get<GetAllDepartmentsResponse>(
                "GetAllDepartmentsUpdated",
                 parameters);

            if (response == null || response.Depts == null)
            {
                return null;
            }

            return response.Depts.Select(x => MappingManager.Map(x)).ToList();
        }

        public async Task<IEnumerable<SmgShortProfile>> GetAllEmployesAsync()
        {
            var response = await Get<GetAllEmployeesResponse>("GetAllEmployees");

            if (response == null || response.Profiles == null)
            {
                return null;
            }

            return response.Profiles.Select(x => MappingManager.Map(x)).ToList();
        }

        public async Task<IEnumerable<SmgShortProfile>> GetEmployeeShortInfoAsync(bool showActiveOnly = true, DateTime? startDate = null)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("initialRequest", showActiveOnly.ToString().ToLower());

            if (startDate.HasValue)
            {
                parameters.Add("updatedDate", startDate.Value.ToShortDateString());
            }

            var response = await Get<GetEmployeesShortInfoResponse>(
                "GetEmployeeShortInfo",
                parameters);

            if (response == null || response.Profiles == null)
            {
                return null;
            }

            return response.Profiles.Select(x => MappingManager.Map(x)).ToList();
        }

        public ProfileFullWS GetEmployeeDetails(int profileId)
        {
            throw new NotImplementedException();
        }

        public ProfileFullWS GetEmployeeDetailsUpdated(int profileId, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmgShortProfile> GetEmployeesByDeptId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SmgShortProfile> GetEmployeesByDeptIdUpdated(int departmentId, bool showActiveOnly = true, DateTime? startDate = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private async Task<T> Get<T>(string methodName, Dictionary<string, string> parameters = null)
            where T : BaseResponse
        {
            var sessionId = await _sessionManager.GetSessionId();

            return RequestManager.Get<T>(
                sessionId,
                methodName,
                parameters).Result;
        }

        #endregion
    }
}
