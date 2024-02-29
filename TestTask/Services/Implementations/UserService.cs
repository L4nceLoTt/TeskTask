using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Data;
using TestTask.Enums;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        ApplicationDbContext context;

        public UserService(ApplicationDbContext dbContext) => this.context = dbContext;

        public Task<User> GetUser()
        {
            return Task.FromResult(context.Users.OrderByDescending(x => x.Orders.Count).First());
        }

        public Task<List<User>> GetUsers()
        {
            return Task.FromResult(context.Users.Where(x => x.Status == UserStatus.Inactive).ToList());
        }
    }
}
