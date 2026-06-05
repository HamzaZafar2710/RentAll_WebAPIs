using RentAll_WebAPIs.Models;

namespace RentAll_WebAPIs.Services
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetAllEquipmentAsync();
        Task<Equipment?> GetEquipmentByIdAsync(int id);
        Task<Equipment> AddEquipmentAsync(Equipment equipment);
        Task<bool> UpdateEquipmentAsync(int id, Equipment equipment);
        Task<bool> DeleteEquipmentAsync(int id);
    }
}