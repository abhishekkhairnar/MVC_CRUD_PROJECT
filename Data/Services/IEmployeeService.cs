using Assignment1.Models;

namespace Assignment1.Data.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> UpdateAsync(int id,Employee newEmployee);
        Task DeleteAsync(int id);
    }
}
