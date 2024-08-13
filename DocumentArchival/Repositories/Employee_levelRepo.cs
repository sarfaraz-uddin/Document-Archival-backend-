using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class Employee_levelRepo:IEmployee_levelRepo
    {
        private readonly ApplicationDbContext _context;

        public Employee_levelRepo(ApplicationDbContext context) 
        { 
                _context = context;
        }

        public async Task<IEnumerable<lvl01employee_level>> GetAll()
        {
            try
            {
                return await _context.lvl01employee_levels.Where(d=>!d.lvl01deleted).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting employee level data", ex);
            }
        }

        public async Task<lvl01employee_level> GetById(int id)
        {
            try
            {
                return await _context.lvl01employee_levels.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while getting Employee level with ID {id}", ex);
            }
        }

        public async Task Add(lvl01employee_levelModel employeeLevel)
        {
            try
            {
        var insertValue = new lvl01employee_level();
                insertValue.lvl01code = employeeLevel.lvl01code;
                insertValue.lvl01title = employeeLevel.lvl01title;
                insertValue.lvl01description = employeeLevel.lvl01description;
                insertValue.lvl01status = employeeLevel.lvl01status;
                insertValue.lvl01deleted = false;
                insertValue.lvl01created_at = DateTime.Now;
                insertValue.lvl01created_by = "Ram";
                _context.lvl01employee_levels.Add(insertValue);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Error occurred while adding employee level data", ex);
            }
            
        }

        public async Task Update(int Id,lvl01employee_levelModel employeeLevel)
        {
            try
            {
                var item = await _context.lvl01employee_levels.FindAsync(Id);
                if (item == null)
                {
                    throw new Exception("Invalid data");
                }
                item.lvl01code = employeeLevel.lvl01code;
                item.lvl01title = employeeLevel.lvl01title;
                item.lvl01description = employeeLevel.lvl01description;
                item.lvl01status = employeeLevel.lvl01status;
                item.lvl01deleted = employeeLevel.lvl01deleted;
                item.lvl01updated_at = DateTime.Now;
                item.lvl01updated_by = "new User";
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while updating employee levels with ID {employeeLevel.lvl01uin}", ex);
            }
            
        }

        public async Task Delete(int id)
        {
            try
            {
                var employeeLevel = await GetById(id);
                if (employeeLevel != null)
                {
                    employeeLevel.lvl01deleted = true;
                    _context.lvl01employee_levels.Update(employeeLevel);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while deleting employee levels with ID {id}", ex);
            }
            
        }
    }
}
