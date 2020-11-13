using System;
using System.Collections.Generic;
using System.Linq;
using Domain.People;

namespace Domain.Players
{
    public class Player : Person
    {
        public Player(string name) : base(name)
        {}

        public (List<string> errors, bool isValid) Validate()
        {
            var errs = new List<string>(); 
            
            if (!ValidateName())
            {
                errs.Add("Invalid name");
            }

            return (errs, errs.Count == 0);
        }
    }
}
