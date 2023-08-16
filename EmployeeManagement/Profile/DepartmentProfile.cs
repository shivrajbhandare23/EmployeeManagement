using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Profile
{
    public class DepartmentProfile
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentViewData>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
