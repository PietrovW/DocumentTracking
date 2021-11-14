using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace DocumentTracking.Infrastructure.Command
{
    public class CreatedUserCommandResult
    {
        public CreatedUserCommandResult()
        {
            Errors = new List<IdentityError>();
        }
        public ICollection<IdentityError> Errors { get; protected set; }

        public bool Succeeded { 
            get { return Errors.Count > 0 ? false : true;  }
            protected set { }
        }
        public string Token { get; set; }

        public void AddErros(IEnumerable<IdentityError> errors)
        {
            if (errors == null && !errors.Any())
                return;

            foreach(IdentityError item in errors)
            {
                Errors.Add(item);
            }
        }
    }
}
