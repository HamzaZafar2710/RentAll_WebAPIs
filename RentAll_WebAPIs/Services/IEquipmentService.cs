using RentAll_WebAPIs.DTOs;
using RentAll_WebAPIs.Models;

namespace RentAll_WebAPIs.Services
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetAllEquipmentAsync();
        Task<Equipment?> GetEquipmentByIdAsync(int id);
        Task<Equipment> AddEquipmentAsync(EquipmentCreateDto dto, string imageUrl);
        Task<bool> UpdateEquipmentAsync(int id, EquipmentUpdateDto dto, string? imageUrl = null);
        Task<bool> DeleteEquipmentAsync(int id);
    }
}