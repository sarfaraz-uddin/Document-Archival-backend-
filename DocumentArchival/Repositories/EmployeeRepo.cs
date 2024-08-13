using DocumentArchival.Interface;
using DocumentArchival.Models.DTO;
using DocumentArchival.Models;
using DocumentArchival.Data;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class EmployeeRepo:IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<emp01employee>> GetAll()
        {
            try
            {
                return await _context.emp01employees
                .Where(e => !e.emp01deleted)
                .ToListAsync();
            }catch(Exception ex)
            {
                throw new Exception("", ex);
            }
            
        }

        public async Task Create(emp01employeeModel employee)
        {
            try
            {
                var insertValue = new emp01employee();
                insertValue.emp01code = employee.emp01code;
                insertValue.emp01des01uin = employee.emp01des01uin;
                insertValue.emp01dep01uin = employee.emp01dep01uin;
                insertValue.emp01lvl01uin = employee.emp01lvl01uin;
                insertValue.emp01bra01uin = employee.emp01bra01uin;
                insertValue.emp01des02uin = employee.emp01des02uin;
                insertValue.emp01name = employee.emp01name;
                insertValue.emp01password = employee.emp01password;
                insertValue.emp01address = employee.emp01address;
                insertValue.emp01email = employee.emp01email;
                insertValue.emp01mobile = employee.emp01mobile;
                insertValue.emp01is_on_leave = employee.emp01is_on_leave;
                insertValue.emp01status = employee.emp01status;
                insertValue.emp01deleted = false;
                insertValue.emp01created_at = DateTime.Now;
                insertValue.emp01created_by = "Ram";
                _context.emp01employees.Add(insertValue);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception("", ex);
            }
        
        }

        public async Task Update(int id, emp01employeeModel employee)
        {
            var existingEmployee = await _context.emp01employees.FindAsync(id);
            if (existingEmployee == null)
            {
                throw new Exception("Employee not found");
            }

            existingEmployee.emp01code = employee.emp01code;
            existingEmployee.emp01des01uin = employee.emp01des01uin;
            existingEmployee.emp01dep01uin = employee.emp01dep01uin;
            existingEmployee.emp01lvl01uin = employee.emp01lvl01uin;
            existingEmployee.emp01bra01uin = employee.emp01bra01uin;
            existingEmployee.emp01des02uin = employee.emp01des02uin;
            existingEmployee.emp01name = employee.emp01name;
            existingEmployee.emp01address = employee.emp01address;
            existingEmployee.emp01email = employee.emp01email;
            existingEmployee.emp01mobile = employee.emp01mobile;
            existingEmployee.emp01status = employee.emp01status;
            existingEmployee.emp01deleted = employee.emp01deleted;
            existingEmployee.emp01updated_by = "new user";
            existingEmployee.emp01updated_at = DateTime.Now;
            existingEmployee.emp01is_on_leave = employee.emp01is_on_leave;

            _context.Entry(existingEmployee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await _context.emp01employees.FindAsync(id);
            if (employee != null)
            {
                employee.emp01deleted = true;
                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
