using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StayZee.Domain.Entities;


namespace StayZee.Application.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> AddUserAsync(User user);
    }
}
