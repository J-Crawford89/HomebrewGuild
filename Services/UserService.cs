using Contracts;
using Data;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly Guid _userId;
        public UserService(Guid userId)
        {
            _ctx = new ApplicationDbContext();
            _userId = userId;
        }
        public IEnumerable<UserListItem> GetAllUsers()
        {
            var users = _ctx.Users.Select(e => new UserListItem
            {
                Email = e.Email,
                UserName = e.UserName
            }).ToList();

            return users;
        }
    }
}
