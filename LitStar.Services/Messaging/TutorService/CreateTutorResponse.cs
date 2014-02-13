using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.TutorService
{
    public class CreateTutorResponse : Response
    {
        public CreateTutorResponse()
        {
            View = new TutorView();
        }
        public TutorView View { get; set; }
    }
}
