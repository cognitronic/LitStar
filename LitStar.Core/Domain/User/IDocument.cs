using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.User
{
    public interface IDocument : ISystemObject
    {
        int UserID { get; set; }
        string Path { get; set; }
        string Title { get; set; }
        DateTime DateCreated { get; set; }
        int EnteredBy { get; set; }
        int SecurityAccessLevel { get; set; }
    }
}
