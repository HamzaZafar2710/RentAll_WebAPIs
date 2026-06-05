using Microsoft.EntityFrameworkCore;
using RentAll_WebAPIs.Data;
using RentAll_WebAPIs.DTOs;
using RentAll_WebAPIs.Models;

namespace RentAll_WebAPIs.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly AppDbContext _context;

        public EquipmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetAllEquipmentAsync()
        {
            return await _context.Equipment.Include(e => e.Owner).ToListAsync();
        }

        public async Task<Equipment?> GetEquipmentByIdAsync(int id)
        {
            return await _context.Equipment.Include(e => e.Owner).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipment> AddEquipmentAsync(EquipmentCreateDto dto, string imageUrl)
        {
            var equipment = new Equipment
            {
                OwnerId = dto.OwnerId,
                Name = dto.Name,
                Description = dto.Description,
                DailyRate = dto.DailyRate,
                IsAvailable = dto.IsAvailable,
                ImageUrl = imageUrl,
                CreatedAt = DateTime.UtcNow
            };

            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }

        public async Task<bool> UpdateEquipmentAsync(int id, EquipmentUpdateDto dto, string? imageUrl = null)
        {
            var existing = await _context.Equipment.FindAsync(id);
            if (existing == null) return false;

            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.DailyRate = dto.DailyRate;
            existing.IsAvailable = dto.IsAvailable;

            if (!string.IsNullOrEmpty(imageUrl))
                existing.ImageUrl = imageUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEquipmentAsync(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment == null)
                return false;

            _context.Equipment.Remove(equipment);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}






