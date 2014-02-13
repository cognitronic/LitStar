using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Services.Messaging.TutorService;

namespace LitStar.Services.Interfaces
{
    public interface ITutorService
    {
        GetTutorListResponse GetTutorList();
        GetTutorResponse GetTutorByEmail(GetTutorByEmailRequest request);
        GetTutorResponse GetTutorByID(int ID);
        CreateTutorResponse CreateTutor(CreateTutorRequest request);
        UpdateTutorResponse UpdateTutor(UpdateTutorRequest request);
    }
}
