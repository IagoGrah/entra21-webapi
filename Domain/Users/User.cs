using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    public class User
    {
        public Guid Id
        {get; set;} = Guid.NewGuid();
        
        public string Name
        {get; set;}

        public Profile Profile
        {get; set;}

        public User(string name, Profile profile)
        {
            Name = name;
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
        
        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');
            if (words.Length < 1)
            {
                return false;
            }

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }
            return true;
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
