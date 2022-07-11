using Microsoft.EntityFrameworkCore;
using SweetShoppp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShoppp.Repositories
{
    public class CakeRepository : ICakeRepository
    {
        private readonly CakeContext _context;
        public CakeRepository(CakeContext context)
        {
            _context = context;
        }

        public async Task<Cake> Create(Cake cake)
        {
            _context.Cakes.Add(cake);
            await _context.SaveChangesAsync();

            return cake;
        }
        public async Task Delete(int id)
        {
            var cakeToDelete = await _context.Cakes.FindAsync(id);
             _context.Cakes.Remove(cakeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cake>> Get()
        {
            return await _context.Cakes.ToListAsync();
        }

        public async Task<Cake> Get(int id)
        {
            return await _context.Cakes.FindAsync(id);
        }

        public async Task Update(Cake Cake)
        {
            _context.Entry(Cake).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}