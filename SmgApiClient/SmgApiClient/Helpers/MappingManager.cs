using SmgApiClient.Models;
using SmgApiClient.SmgModels.Containers;

namespace SmgApiClient
{
    internal static class MappingManager
    {
        public static SmgDepartment Map(DepartmentWS departmentContainer)
        {
            return new SmgDepartment
            {
                Id = departmentContainer.Id,
                Code = departmentContainer.DepCode,
                Name = departmentContainer.Name,
                EmployeesCount = departmentContainer.NumUsers
            };
        }

        public static SmgShortProfile Map(ProfileShortWS shortProfileContainer)
        {
            return new SmgShortProfile
            {
                Id = shortProfileContainer.ProfileId,
                FirstName = shortProfileContainer.FirstName,
                LastName = shortProfileContainer.LastName,
                FirstNameEng = shortProfileContainer.FirstNameEng,
                LastNameEng = shortProfileContainer.LastNameEng,
                DepartmentId = shortProfileContainer.DeptId,
                Position = shortProfileContainer.Position,
                Room = shortProfileContainer.Room,
                PhotoUrl = shortProfileContainer.Photo,
                IsEnabled = shortProfileContainer.IsEnabled
            };
        }
    }
}
