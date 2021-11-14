using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DocumentTracking.Infrastructure.Models
{
    public abstract class BaseResult
    {
        public BaseResult()
        {
            Errors = new List<IdentityError>();
        }
        public ICollection<IdentityError> Errors { get; protected set; } = new List<IdentityError>();

        public bool Succeeded
        {
            get { return Errors.Count > 0 ? false : true; }
            protected set { }
        }
        
        public void AddErro(IdentityError error)
        {
            Errors.Add(error);
        }

        public void AddErros(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                Errors.Add(item);
            }
        }
    }
}
