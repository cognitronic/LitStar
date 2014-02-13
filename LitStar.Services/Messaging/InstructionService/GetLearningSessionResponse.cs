using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Instruction;
using LitStar.Services.Messaging;

namespace LitStar.Services.Messaging.InstructionService
{
    public class GetLearningSessionResponse : Response
    {
        public ILearningSession LearningSession{ get; set; }
    }
}
