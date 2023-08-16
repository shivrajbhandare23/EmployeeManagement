using AutoMapper;
using EmployeeManagement.ViewModel;
using EmployeeManagement.Models;

namespace BancoAssignment.Profile
{
    public static class EmployeeProfile
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeesViewData>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
