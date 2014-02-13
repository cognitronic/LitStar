using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Account
{
    public interface IAccount : ISystemObject
    {
        string Name { get; set; }
        int AccountTypeID { get; set; }
        AccountType AccountType { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string Email { get; set; }
        string Website { get; set; }
    }
}
