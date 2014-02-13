using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;

namespace LitStar.Services.Messaging.LearnerService
{
    public class GetLearnerByEmailRequest
    {
        public string Email { get; set; }
    }
}
