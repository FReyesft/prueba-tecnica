using AutoMapperDemo;
using Inmersys.Core.Dtos;
using Inmersys.Core.Models;
using Inmersys.Core.Repositories;
using Inmersys.Core.Services;
using Microsoft.VisualBasic;

namespace Inmersys.Bussines.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetListEmployeesDto> GetAllEmployeesAsync()
        {
            GetListEmployeesDto response = new();
            try
            {
                var users = await _unitOfWork.Employees.GetAllAsync();
                response.Employees = users.ToList();
            }
            catch (Exception ex) { 
                response.Error.IsError = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }

        public async Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeRequestDto employee)
        {
            EmployeeResponseDto response = new();
            var mapper = MapperConfig.InitializeAutomapper();
            try
            {
                if (string.IsNullOrEmpty(employee.Name))
                {
                    throw new Exception("El nombre del empleado es obligatorio");
                }
                if (string.IsNullOrEmpty(employee.LastName))
                {
                    throw new Exception("El apellido del empleado es obligatorio");
                }

                var newEmployee = mapper.Map<Employees>(employee);

                await _unitOfWork.Employees.AddAsync(newEmployee);

                await _unitOfWork.CommitAsync();

                response = mapper.Map<EmployeeResponseDto>(newEmployee);

            }
            catch (Exception)
            {
                response.Error.IsError = true;
                response.Error.Message = "Ocurrio un error añadiendo el empleado";
            }

            return response;
        }

        public async Task<EmployeeResponseDto> UpdateEmployeeAsync(int IdEmployee, CreateEmployeeRequestDto employee)
        {
            EmployeeResponseDto response = new();
            var mapper = MapperConfig.InitializeAutomapper();
            try
            {

                if (string.IsNullOrEmpty(employee.Name))
                {
                    throw new Exception("El nombre del empleado es obligatorio");
                }
                if (string.IsNullOrEmpty(employee.LastName))
                {
                    throw new Exception("El apellido del empleado es obligatorio");
                }

                var findedUser = await _unitOfWork.Employees.GetByIdAsync(IdEmployee);

                findedUser.Name = employee.Name;
                findedUser.LastName = employee.LastName;

                var updatedUser = mapper.Map<Employees>(employee);

                await _unitOfWork.CommitAsync();

                response = mapper.Map<EmployeeResponseDto>(updatedUser);
            }
            catch (Exception ex)
            {
                response.Error.IsError = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }

        public async Task<EmployeeResponseDto> DeleteEmployeeAsync(int IdEmployee)
        {
            EmployeeResponseDto response = new();
            var mapper = MapperConfig.InitializeAutomapper();
            try
            {
                if(IdEmployee <= 0)
                {
                    throw new Exception("No se envió un argumento valido");
                }

                var employee = await _unitOfWork.Employees.GetByIdAsync(IdEmployee);

                if (employee == null) {
                    throw new Exception("No se encontro un empleado");
                }

                _unitOfWork.Employees.Remove(employee);

                await _unitOfWork.CommitAsync();

                response = mapper.Map<EmployeeResponseDto>(employee);
            }
            catch(Exception ex)
            {
                response.Error.IsError = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }

        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(int IdEmployee)
        {
            EmployeeResponseDto response = new();
            var mapper = MapperConfig.InitializeAutomapper();
            try
            {
                if (IdEmployee <= 0)
                {
                    throw new Exception("No se envió un argumento valido");
                }

                var employee = await _unitOfWork.Employees.GetByIdAsync(IdEmployee);

                if (employee == null)
                {
                    throw new Exception("No se encontro un empleado");
                }

                response = mapper.Map<EmployeeResponseDto>(employee);
            }
            catch (Exception ex)
            {
                response.Error.IsError = true;
                response.Error.Message = ex.Message;
            }

            return response;
        }
    }
}
