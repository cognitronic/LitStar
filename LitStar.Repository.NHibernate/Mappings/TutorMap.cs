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
    public class TutorMap : ClassMap<Tutor>
    {
        public TutorMap()
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
            Map(x => x.ChangedBy);
            Map(x => x.EnteredBy);
            Map(x => x.EmergencyContactName);
            Map(x => x.Ethnicity).CustomType(typeof(EthnicityType));
            Map(x => x.EducationCompleted).CustomType(typeof(EducationLevel));
            Map(x => x.EmergencyContactPhone);
            Map(x => x.Phone);
            Map(x => x.State);
            Map(x => x.IsBillingual);
            Map(x => x.Occupation);
            Map(x => x.ReferredBy);
            Map(x => x.Sex);
            Map(x => x.UserID);
            Map(x => x.Zip);
            References<User>(x => x.Membership)
                .Column("UserID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
            References<Account>(x => x.Account)
                .Column("AccountID")
                .NotFound
                .Ignore()
                .Not.Update()
                .Not.Insert();
        }
    }
}
