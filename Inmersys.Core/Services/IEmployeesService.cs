using Inmersys.Core.Dtos;
using Inmersys.Core.Models;

namespace Inmersys.Core.Services
{
    public interface IEmployeesService
    {
        Task<GetListEmployeesDto> GetAllEmployeesAsync();
        Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeRequestDto employee);
        Task<EmployeeResponseDto> UpdateEmployeeAsync(int IdEmployee, CreateEmployeeRequestDto employee);
        Task<EmployeeResponseDto> DeleteEmployeeAsync(int IdEmployee);
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(int IdEmployee);

    }
}
