﻿using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Schedulings
{
    public class SchedulingsRepository : ISchedulingsRepository
    {
        private ApplicationDbContext _context;

        public SchedulingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Scheduling scheduling)
        {
            await _context.Schedulings.AddAsync(scheduling);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var scheduling = await GetByIdAsync(id);
            _context.Schedulings.Remove(scheduling);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Scheduling>> GetAllAsync()
        {
            return await _context.Schedulings
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Scheduling?> GetByIdAsync(int id)
        {
            var scheduling = await _context.Schedulings
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .SingleOrDefaultAsync(s => s.Id == id);
            return scheduling;
        }
    }
}
