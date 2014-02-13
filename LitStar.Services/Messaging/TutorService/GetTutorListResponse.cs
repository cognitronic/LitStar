using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.Messaging;

namespace LitStar.Services.Messaging.TutorService
{
    public class GetTutorListResponse : Response
    {
        public IList<ITutor> Tutors { get; set; }
    }
}
