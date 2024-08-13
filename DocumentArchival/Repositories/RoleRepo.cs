using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class RoleRepo : IRoleRepo
    {
        private readonly ApplicationDbContext _context;

        public RoleRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<rol01role>> GetAllAsync()
        {
            return await _context.rol01roles.Where(e=>!e.rol01deleted).Include(d=>d.emp01employee).ToListAsync();
        }

        public async Task AddAsync(rol01roleModel rol01Role)
        {
            try
            {
                var insertValue = new rol01role();
                insertValue.rol01title = rol01Role.rol01title;
                insertValue.rol01deleted = false;
                insertValue.rol01created_at = DateTime.Now;
                insertValue.rol01created_by = "Ram";
                insertValue.rol01updated_at = DateTime.Now;
                insertValue.rol01updated_by = "Ram";
                insertValue.rol01emp01uin = rol01Role.rol01emp01uin;
                _context.rol01roles.Add(insertValue);
               await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception("",ex);
            }
        }

        public async Task UpdateAsync(int Id, rol01roleModel rol01Role)
        {
            try
            {
                var item = await _context.rol01roles.FindAsync(Id);
                if (item == null)
                {
                    throw new Exception("Invalid data");
                }
                item.rol01title = rol01Role.rol01title;
                item.rol01emp01uin=rol01Role.rol01emp01uin;
                item.rol01updated_at = DateTime.Now;
                item.rol01updated_by = "Nobody";
                item.rol01deleted = rol01Role.rol01deleted;
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int Id)
        {
            var item = await _context.rol01roles.FindAsync(Id);
            if (item != null)
            {
                item.rol01deleted = true;
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<DropdownDTO>> GetRolesIdAndName()
        {
            return await _context.rol01roles
                            .Select(m => new DropdownDTO
                            {
                                Id = m.rol01uin,
                                Title = m.rol01title
                            })
                            .ToListAsync();
        }
    }
}
