using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    public class UsersService
    {
        public CreatedUserDTO Create(string name, Profile profile)
        {
            var user = new User(name, profile);
            var userVal = user.Validate();

            if (!userVal.isValid)
            {   
                return new CreatedUserDTO(userVal.errors);
            }
            
            var usersRepository = new UsersRepository();
            usersRepository.Add(user);
            return new CreatedUserDTO(user.Id);
        }

        public User GetByID(Guid id)
        {
            var usersRepository = new UsersRepository();
            return usersRepository.GetByID(id);
        }

        public IEnumerable<User> GetAll()
        {
            var usersRepository = new UsersRepository();
            return usersRepository.GetAll();
        }
    }
}
