using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.User
{
    public interface ILearner : IUser, IHasAddress, IAuditable
    {
        string Phone { get; set; }
        bool Sex { get; set; }
        DateTime Birthdate { get; set; }
        EthnicityType Ethnicity { get; set; }
        bool IsBillingual { get; set; }
        bool IsCitizen { get; set; }
        bool HasChildren { get; set; }
        EducationLevel EducationCompleted { get; set; }
        string Occupation { get; set; }
        string ReferredBy { get; set; }
        string Employer { get; set; }
        string EmergencyContactName { get; set; }
        string EmergencyContactPhone { get; set; }
        string PlaceOfBirth { get; set; }
        string ReasonForTutoring { get; set; }
        int UserID { get; set; }
        bool IsMatched { get; set; }
        ITutor CurrentTutor { get; set; }
        IUser Membership { get; set; }
    }
}
