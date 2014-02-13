using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.User;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.InstructionService
{
    public class CreateLearningSessionResponse : Response
    {
        public CreateLearningSessionResponse()
        {
            View = new InstructionView();
        }
        public InstructionView View { get; set; }
    }
}
