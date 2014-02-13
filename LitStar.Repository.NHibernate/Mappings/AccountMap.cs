using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LitStar.Core.Domain.Account;

namespace LitStar.Repository.NHibernate.Mappings
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Id(x => x.ID);
            Map(x => x.Address1);
            Map(x => x.Address2);
            Map(x => x.AccountTypeID);
            Map(x => x.Email);
            Map(x => x.Website);
            Map(x => x.City);
            Map(x => x.Phone);
            Map(x => x.State);
            Map(x => x.Zip);
            Map(x => x.Name);
            Map(x => x.Fax);
        }
    }
}
