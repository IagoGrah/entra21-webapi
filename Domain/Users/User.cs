using System;
using System.Collections.Generic;
using System.Linq;
using Domain.People;

namespace Domain.Users
{
    public class User : Person
    {
        public Profile Profile
        {get; set;}

        public User(string name, Profile profile) : base(name)
        {
            Profile = profile;
        }

        public (List<string> errors, bool isValid) Validate()
        {
            var errs = new List<string>(); 
            
            if (!ValidateName())
            {
                errs.Add("Invalid name");
            }
            if (!ValidateProfile())
            {
                errs.Add("Invalid profile");
            }
            return (errs, errs.Count == 0);
        }
        
        private bool ValidateProfile()
        {
            if (!Enum.IsDefined(typeof(Profile), Profile))
            {
                return false;
            }

            return true;
        }
    }
}
