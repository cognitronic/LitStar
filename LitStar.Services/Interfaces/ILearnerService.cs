using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.Messaging.LearnerService;

namespace LitStar.Services.Interfaces
{
    public interface ILearnerService
    {
        GetLearnerListResponse GetLearnerList();
        GetLearnerResponse GetLearnerByEmail(GetLearnerByEmailRequest request);
        GetLearnerResponse GetLearnerByID(int ID);
        CreateLearnerResponse CreateLearner(CreateLearnerRequest request);
        UpdateLearnerResponse UpdateLearner(UpdateLearnerRequest request);
    }
}
