using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoAddressService
    {
        Task<TodoAddress[]> GetIncompleteAddressAsync(ApplicationUser user);
        Task<bool> AddAddressAsync(TodoAddress newAddress, ApplicationUser user, string address);
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
        
        
    }
}