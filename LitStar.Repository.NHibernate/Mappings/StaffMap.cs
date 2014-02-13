using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LitStar.Core.Domain.User;

namespace LitStar.Repository.NHibernate.Mappings
{
    public class StaffMap : ClassMap<Staff>
    {
        public StaffMap()
        {
            Id(x => x.ID);
            Map(x => x.Address1);
            Map(x => x.Address2);
            Map(x => x.Birthdate);
            Map(x => x.DateCreated);
            Map(x => x.LastUpdated);
            Map(x => x.City);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            Map(x => x.AvatarPath);
            Map(x => x.IsActive);
            Map(x => x.AccountID);
            Map(x => x.HireDate);
            Map(x => x.ChangedBy);
            Map(x => x.EnteredBy);
            Map(x => x.ManagerID);
            Map(x => x.PayFrequency).CustomType(typeof(PayFrequency)); ;
            Map(x => x.PayRate);
            Map(x => x.Phone);
            Map(x => x.State);
            Map(x => x.TerminationDate).Nullable();
            Map(x => x.Title);
            Map(x => x.IsManager);
            Map(x => x.UserID);
            Map(x => x.Zip);
            References<User>(x => x.Membership)
                .Column("UserID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
            References<Staff>(x => x.Manager)
                .Column("ManagerID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
        }
    }
}
