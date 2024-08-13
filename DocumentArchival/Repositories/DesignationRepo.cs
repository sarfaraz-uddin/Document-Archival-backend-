using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class DesignationRepo:IDesignationRepo
    {
        private readonly ApplicationDbContext _context;

        public DesignationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<des01designation>> GetAll()
        {
            try
            {
                return await _context.des01designations.Where(d=>!d.des01deleted).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Error occurred while getting designation data", ex);
            }
            
        }

        public async Task<des01designation> GetById(int id)
        {
            try
            {
                return await _context.des01designations.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while getting designation with ID {id}", ex);
            }
            
        }

        public async Task Add(des01designationModel designation)
        {
            try
            {
                var insertValue = new des01designation();
                insertValue.des01code = designation.des01code;
                insertValue.des01title = designation.des01title;
                insertValue.des01description = designation.des01description;
                insertValue.des01status = designation.des01status;
                insertValue.des01deleted = false;
                insertValue.des01created_at = DateTime.Now;
                insertValue.des01created_by = "Ram";
                _context.des01designations.Add(insertValue);
                await _context.SaveChangesAsync();
    }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Error occurred while adding designation data", ex);
            }
            
        }

        public async Task Update(int Id,des01designationModel designation)
        {
            try
            {
                var item = await _context.des01designations.FindAsync(Id);
                if (item == null)
                {
                    throw new Exception("Invalid data");
                }
                item.des01code = designation.des01code;
                item.des01title = designation.des01title;
                item.des01description = designation.des01description;
                item.des01status = designation.des01status;
                item.des01deleted = designation.des01deleted;
                item.des01updated_at = DateTime.Now;
                item.des01updated_by = "new User";

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while updating designation with ID {designation.des01uin}", ex);
            }
            
        }
        public async Task Delete(int id)
        {
            try
            {
                var designation = await GetById(id);
                if (designation != null)
                {
                    designation.des01deleted = true;
                    _context.des01designations.Update(designation);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while deleting designation with ID {id}", ex);
            }
            
        }
    }
}
    

