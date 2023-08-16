using AutoMapper;
using BancoAssignment.Profile;
using EmployeeManagement.Models;
using EmployeeManagement.Profile;
using EmployeeManagement.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeManagementContext _dbContext;

        private readonly IMapper _mapper;

        public DepartmentRepository(EmployeeManagementContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = DepartmentProfile.InitializeAutomapper();
        }

        public async Task<IList<DepartmentViewData>> GetDepartment()
        {
            var departmentResult = await _dbContext.Departments.ToListAsync();
            return _mapper.Map<IList<DepartmentViewData>>(departmentResult);
        }

        public async Task<int> AddDepartment(DepartmentViewData department)
        {
            var departmentData = new Department()
            {
                DepartmentName = department.DepartmentName,                
            };

            _dbContext.Departments.Add(departmentData);
            await _dbContext.SaveChangesAsync();

            return departmentData.DeptId;
        }

        public async Task<DepartmentViewData> GetDepartmentByID(int id)
        {
            var departmentResult = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DeptId == id);
            return _mapper.Map<DepartmentViewData>(departmentResult);
        }

        public async Task<bool> UpdateDepartment(DepartmentViewData department)
        {
            Department? deptRecord = await _dbContext.Departments.SingleOrDefaultAsync(x => x.DeptId == department.DeptId);

            int isUpdated;
            if (deptRecord != null)
            {
                deptRecord.DepartmentName = department.DepartmentName;
                isUpdated = await _dbContext.SaveChangesAsync();
                return (isUpdated > 0);
            }
            return false;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            int isDepartmentDeleted;
            var departmentResult = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DeptId == id);
            if (departmentResult != null)
            {
                _dbContext.Departments.Remove(departmentResult);
                isDepartmentDeleted = await _dbContext.SaveChangesAsync();
                return (isDepartmentDeleted > 0);

            }
            return false;
        }

    }
}
