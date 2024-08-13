using DocumentArchival.Data;
using DocumentArchival.Models;
using DocumentArchival.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace DocumentArchival.Repositories
{
    public class ProvinceRepo : IProvinceRepo
    {
        private readonly ApplicationDbContext _context;

        public ProvinceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<set03province>> GetAllAsync()
        {
            return await _context.set03provinces.ToListAsync();
        }

        public async Task AddAsync(set03province item)
        {
            _context.set03provinces.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(byte Id, set03provinceModel set03ProvinceModel)
        {
            try
            {
                var item = await _context.set03provinces.FindAsync(Id);
                if (item == null)
                {
                    throw new Exception("Invalid data");
                }
                item.set03updated_at = DateTime.Now;
                item.set03updated_by = "Nobody";
                item.set03code = set03ProvinceModel.set03code;
                item.set03title = set03ProvinceModel.set03title;
                item.set03remarks = set03ProvinceModel.set03remarks;
                item.set03status = set03ProvinceModel.set03status;
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(byte Id)
        {
            var item = await _context.set03provinces.FindAsync(Id);
            if (item != null)
            {
                item.set03deleted = true;
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
