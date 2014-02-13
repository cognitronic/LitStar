using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.LearnerService
{
    public class UpdateLearnerResponse : Response
    {
        public UpdateLearnerResponse()
        {
            View = new LearnerView();
        }
        public LearnerView View { get; set; }
    }
}
