using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Instruction;

namespace LitStar.Services.Messaging.InstructionService
{
    public class CreateLearningSessionRequest
    {
        public ILearningSession LearningSession { get; set; }
    }
}
