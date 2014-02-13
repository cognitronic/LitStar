using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.User
{
    public interface IStaff : IUser, IAuditable, IHasAddress
    {
        string Title { get; set; }
        string Phone { get; set; }
        DateTime Birthdate { get; set; }
        DateTime HireDate { get; set; }
        int ManagerID { get; set; }
        decimal PayRate { get; set; }
        PayFrequency PayFrequency { get; set; }
        int UserID { get; set; }
        IUser Membership { get; set; }
        DateTime? TerminationDate { get; set; }
        IStaff Manager { get; set; }
        bool IsManager { get; set; }
        new string Email { get; set; }
        new string FirstName { get; set; }
        new string LastName { get; set; }
        new bool IsActive { get; set; }
        new string AvatarPath { get; set; }
        new int AccountID { get; set; }
    }
}
