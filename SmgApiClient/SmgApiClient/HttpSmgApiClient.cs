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

        public async Task<IEnumerable<SmgShortProfile>> GetEmployeesByDeptartmentAsync(int departmentId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "departmentId", departmentId.ToString() }
            };

            var response = await Get<GetEmployeesByDeptIdResponse>(
                "GetEmployeesByDeptId",
                parameters);

            if (response == null || response.Profiles == null)
            {
                return null;
            }

            return response.Profiles.Select(x => MappingManager.Map(x)).ToList();
        }

        public async Task<IEnumerable<SmgShortProfile>> GetEmployeesByDepartmentUpdatedAsync(
            int departmentId,
            bool showActiveOnly = true,
            DateTime? startDate = null)
        {
            var parameters = new Dictionary<string, string>
            {
                { "departmentId", departmentId.ToString() },
                { "initialRequest", showActiveOnly.ToString().ToLower() }
            };

            if (startDate.HasValue)
            {
                parameters.Add("updatedDate", startDate.Value.ToShortDateString());
            }

            var response = await Get<GetEmployeesByDeptIdResponse>(
                "GetEmployeesByDeptIdUpdated",
                parameters);

            if (response == null || response.Profiles == null)
            {
                return null;
            }

            return response.Profiles.Select(x => MappingManager.Map(x)).ToList();
        }

        public async Task<SmgFullProfile> GetEmployeeDetails(int employeeId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "profileId", employeeId.ToString() }
            };

            var response = await Get<GetEmployeeDetailsResponse>(
                "GetEmployeeDetails",
                parameters);

            if (response == null || response.Profile == null)
            {
                return null;
            }

            return MappingManager.Map(response.Profile);
        }

        public SmgFullProfile GetEmployeeDetailsUpdated(int profileId, DateTime startDate)
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
