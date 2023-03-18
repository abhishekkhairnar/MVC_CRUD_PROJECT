using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(result);
            await _context.SaveChangesAsync();
        }
        

        public async Task< IEnumerable<Employee> > GetAllAsync()
        {
            var data = await _context.Employees.ToListAsync();
            return data;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Employee> UpdateAsync(int id, Employee newEmployee)
        {
            _context.Update(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
        }
    }
}
