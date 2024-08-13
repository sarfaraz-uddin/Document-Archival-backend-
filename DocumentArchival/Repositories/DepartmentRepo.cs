using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _dbcontext;
        public DepartmentRepo(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Create(dep01department department)
        {
            try
            {

                await _dbcontext.dep01departments.AddAsync(department);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }

        public async Task<IEnumerable<dep01department>> GetAll()
        {
            try
            {
                return await _dbcontext.dep01departments.Where(d => !d.dep01deleted).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }

        public async Task Update(dep01departmentModel department)
        {
            try
            {
                var isDepartmentExists = await _dbcontext.dep01departments.FindAsync(department.dep01uin);
                if (isDepartmentExists == null)
                {
                    throw new Exception("Invalid data");
                }
                
                isDepartmentExists.dep01title = department.dep01title;
                isDepartmentExists.dep01code = department.dep01code;
                isDepartmentExists.dep01status = department.dep01status;
                isDepartmentExists.dep01deleted = department.dep01deleted;
                isDepartmentExists.dep01updated_by = "Logged in user";
                isDepartmentExists.dep01updated_at = DateTime.Now;
                _dbcontext.Update(isDepartmentExists);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var department = await _dbcontext.dep01departments.FindAsync(id);
                if (department == null)
                {
                    throw new Exception("Invalid data");
                }
                department.dep01deleted = true;
                _dbcontext.dep01departments.Update(department);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }
        public async Task<IEnumerable<DropdownDTO>> GetDepartmentsIdAndName()
        {
            return await _dbcontext.dep01departments
                            .Select(m => new DropdownDTO
                            {
                                Id = m.dep01uin,
                                Title = m.dep01title
                            })
                            .ToListAsync();
        }

    }
}
