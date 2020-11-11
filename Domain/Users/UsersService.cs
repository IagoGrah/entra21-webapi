using System;
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
            
            UsersRepository.Add(user);
            return new CreatedUserDTO(user.Id);
        }

        public User GetByID(Guid id)
        {
            return UsersRepository.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
