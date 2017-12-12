using SmgApiClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmgApiClient.Interfaces
{
    public interface ISmgApiClient
    {
        Task<IEnumerable<SmgDepartment>> GetAllDepartmentsAsync();

        Task<IEnumerable<SmgDepartment>> GetAllDepartmentsUpdatedAsync(DateTime startDate);

        Task<IEnumerable<SmgShortProfile>> GetAllEmployesAsync();

        Task<IEnumerable<SmgShortProfile>> GetEmployeeShortInfoAsync(bool showActiveOnly = true, DateTime? startDate = null);

        Task<IEnumerable<SmgShortProfile>> GetEmployeesByDeptartmentAsync(int departmentId);

        Task<IEnumerable<SmgShortProfile>> GetEmployeesByDepartmentUpdatedAsync(
            int departmentId,
            bool showActiveOnly = true,
            DateTime? startDate = null);

        ProfileFullWS GetEmployeeDetails(int profileId);

        ProfileFullWS GetEmployeeDetailsUpdated(int profileId, DateTime startDate);
    }
}
