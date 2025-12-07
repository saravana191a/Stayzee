using StayZee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayZee.Application.Interfaces.IRepository
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id);
        Task<Customer?> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
    }
}
