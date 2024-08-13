using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace DocumentArchival.Repositories
{
    public class Functional_titleRepo:IFunctional_titleRepo
    {
        private readonly ApplicationDbContext _context;

        public Functional_titleRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<des02functional_title>> GetAll()
        {
            try
            {
                return await _context.des02functional_titles.Where(d=>!d.des02deleted).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Error occurred while getting all functional titles", ex);
            }
        }

        public async Task<des02functional_title> GetById(int id)
        {
            try
            {
                return await _context.des02functional_titles.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while getting functional title with ID {id}", ex);
            }
            
        }

        public async Task Add(des02functional_titleModel functionalTitle)
        {
            try
            {
        var insertValue = new des02functional_title();
                insertValue.des02code = functionalTitle.des02code;
                insertValue.des02title = functionalTitle.des02title;
                insertValue.des02remarks = functionalTitle.des02remarks;
                insertValue.des02status = functionalTitle.des02status;
                insertValue.des02deleted = false;
                insertValue.des02created_at = DateTime.Now;
                insertValue.des02created_by = "Ram";
                _context.des02functional_titles.Add(insertValue);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Error occurred while adding functional title", ex);
            }
            
        }

        public async Task Update(int Id,des02functional_titleModel functionalTitle)
        {
            try
            {
                var item = await _context.des02functional_titles.FindAsync(Id);
                if (item == null)
                {
                    throw new Exception("Invalid data");
                }
                item.des02code = functionalTitle.des02code;
                item.des02title = functionalTitle.des02title;
                item.des02remarks = functionalTitle.des02remarks;
                item.des02status = functionalTitle.des02status;
                item.des02deleted = functionalTitle.des02deleted;
                item.des02updated_at = DateTime.Now;
                item.des02updated_by = "new User";
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while updating functional title with ID {functionalTitle.des02uin}", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var functionalTitle = await GetById(id);
                if (functionalTitle != null)
                {
                    functionalTitle.des02deleted = true;
                    _context.des02functional_titles.Update(functionalTitle);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while deleting functional title with ID {id}", ex);
            }
            
        }

    }
}
