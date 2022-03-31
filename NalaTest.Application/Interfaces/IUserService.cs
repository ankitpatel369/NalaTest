using NalaTest.Domain.Entity;
using NalaTest.Domain.Entity.DTOs;

namespace NalaTest.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResultTyped<IList<UserDto>>> GetAllActiveUsers();
        Task<ResultTyped<IList<UserDto>>> GetAllInActiveFemaleUsers();
        Task<ResultTyped<UserDto>> FindUserByEmail(string email);
    }
}
