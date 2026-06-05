using Microsoft.EntityFrameworkCore;
using RentAll_WebAPIs.Data;
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
            return await _context.Equipment.ToListAsync();
        }

        public async Task<Equipment?> GetEquipmentByIdAsync(int id)
        {
            return await _context.Equipment.FindAsync(id);
        }

        public async Task<Equipment> AddEquipmentAsync(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }

        public async Task<bool> UpdateEquipmentAsync(int id, Equipment equipment)
        {
            var existing = await _context.Equipment.FindAsync(id);

            if (existing == null)
                return false;

            existing.Name = equipment.Name;
            existing.Description = equipment.Description;
            existing.DailyRate = equipment.DailyRate;
            existing.ImageUrl = equipment.ImageUrl;
            existing.IsAvailable = equipment.IsAvailable;

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