using RentAll_WebAPIs.Models;
public interface IUserRepository
{
    Task<User?> GetByEmailAsync(
        string email);
}