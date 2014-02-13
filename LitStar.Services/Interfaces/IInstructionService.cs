using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.Messaging.InstructionService;

namespace LitStar.Services.Interfaces
{
    public interface IInstructionService
    {
        GetLearningSessionListResponse GetLearningSessionList();
        GetLearningSessionResponse GetLearningSessionByID(int ID);
        CreateLearningSessionResponse CreateLearningSession(CreateLearningSessionRequest request);
        UpdateLearningSessionResponse UpdateLearningSession(UpdateLearningSessionRequest request);
    }
}
