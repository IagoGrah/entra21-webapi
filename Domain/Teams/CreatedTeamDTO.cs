using System;
using System.Collections.Generic;

namespace Domain.Teams
{
    public class CreatedTeamDTO
    {
        public Guid Id { get; set; }
        public List<string> Errors { get; set; }
        public bool IsValid { get; set; }
        
        public CreatedTeamDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }
        public CreatedTeamDTO(List<string> errors)
        {
            Errors = errors;
        }
    }
}
