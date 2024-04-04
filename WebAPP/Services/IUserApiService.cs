using Refit;

namespace WebAPP;

public interface IUserApiService
{
    [Get("/User/GetAllUsers")]
    Task<List<User>> GetAllUsers();

    [Get("/User/GetUserByID/{id}")]
    Task<User> GetUserByID(int id);

    [Post("/User/AddUser")]
    Task AddUser([Body] User user);

    [Put("/User/UpdateUser/{id}")]
    Task UpdateUser(int id, [Body] User user);

    [Delete("/User/DeleteUser/{id}")]
    Task DeleteUser(int id);
    
}
