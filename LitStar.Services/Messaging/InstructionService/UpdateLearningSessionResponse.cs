using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Instruction;
using LitStar.Services.ViewModels;

namespace LitStar.Services.Messaging.InstructionService
{
    public class UpdateLearningSessionResponse : Response
    {
        public UpdateLearningSessionResponse()
        {
            View = new InstructionView();
        }
        public InstructionView View { get; set; }
    }
}
