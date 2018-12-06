using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AspNetCoreTodo.UnitTests
{
    public class TodoAddressServiceShould
    {
        [Fact]
        public async Task AddNewAddressAsIncompleteWithDueDate()
        {
            var options = new DbContextOptionsBuilder<AspNetCoreTodo.Data.ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_AddNewAddress").Options;

            // Set up a context (connection to the "DB") for writing
            using (var context = new ApplicationDbContext(options))
            {
                var service = new TodoAddressService(context);

                var fakeUser = new ApplicationUser
                {
                    Id = "fake-000",
                    UserName = "fake@example.com"
                };

                await service.AddAddressAsync(new TodoAddress)
                {
                    Title = "Testing?"
                }, fakeUser);
            }
            // Use a separate context to read data back from the "DB"
            using (var context = new ApplicationDbContext(options))
            {
                var addressesInDatabase = await context
                    .Addresses.CountAsync();
                Assert.Equal(1, addressInDatabase);

                var address = await context.Addresses.FirstAsync();
                Assert.Equal("Testing?", address.Title);
                Assert.Equal(false, Address.IsDone);

                // Item should be due 3 days from now (give or take a second)
                var difference = DateTimeOffset.Now.AddDays(3) - item.DueAt;
                Assert.True(difference < TimeSpan.FromSeconds(1));
            }
        }
        

        

          [Fact]
        public async Task GetItemIncompleteAsycOfTheCorrectUser()
        {
            var options = new DbContextOptionsBuilder<AspNetCoreTodo.Data.ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Test_AddNewAddress").Options;

            using (var context = new ApplicationDbContext(options))
            {      
                var service = new TodoAddressService(context);
                var fakeUser = new ApplicationUser
                {
                    Id = "fake-000",
                    UserName = "fake@example.com"
                };

                await service.AddAddressAsync(new TodoAddress {Title = "Testing?"}, fakeUser);
                var address = await context.Adresses.FirstAsync();
                TodoAddress[] address = await service.GetIncompleteItemsAsync(fakeUser);
                Assert.True(address[0].UserId == "fake-000");
            }

        }
    }
}
    
