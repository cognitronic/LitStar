using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.User
{
    public class EmailValidationSpecification : ISpecification<string>
    {
        private static Regex _emailregex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public bool IsSatisfiedBy(string email)
        {
            return _emailregex.IsMatch(email);
        }
    }
}
