using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.Messaging;

namespace LitStar.Services.Messaging.LearnerService
{
    public class GetLearnerListResponse : Response
    {
        public IList<ILearner> Learners { get; set; }
    }
}
