using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LitStar.Core.Domain.User;
using LitStar.Core.Domain.Account;

namespace LitStar.Repository.NHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.ID);
            Map(x => x.Username);
            Map(x => x.DateCreated);
            Map(x => x.LastUpdated);
            Map(x => x.Password);
            Map(x => x.AccessLevel);
            Map(x => x.AccountID);
            Map(x => x.ChangedBy);
            Map(x => x.EnteredBy);
            Map(x => x.LastLoggedIn);
            Map(x => x.SecurityAnswer);
            Map(x => x.SecurityQuestion);
            References<Account>(x => x.Account)
                .Column("AccountID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
            Map(x => x.UserType).Column("UserType").CustomType(typeof(UserType));
        }
    }
}
