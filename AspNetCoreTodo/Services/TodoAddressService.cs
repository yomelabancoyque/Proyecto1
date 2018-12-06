using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoAddressService : ITodoAddressService
    {
        private readonly ApplicationDbContext _context;

        public TodoAddressService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TodoAddress[]> GetIncompleteAddressesAsync(ApplicationUser user)
        {
            return await _context.Addresses
                .Where(x => x.IsDone == false  && x.UserId == user.Id)
                .ToArrayAsync();
                
            
         }

        public async Task<bool> AddAddressAsync(<TodoAddress newAddress, ApplicationUser user, string Address)
        {
            newAddress.Id = Guid.NewGuid();
            newAddress.IsDone = false;
            newAddress.DueAt = DateTimeOffset.Now.AddDays(3);
            newAddress.UserId = user.Id;
            newAddress.Address = address;


            _context.Addresses.Add(newAddress);
            
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    
        

       
    }
}