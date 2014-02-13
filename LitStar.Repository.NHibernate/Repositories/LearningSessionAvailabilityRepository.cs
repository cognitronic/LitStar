﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Core.Domain.Preference;
using LitStar.Infrastructure.Domain;
using LitStar.Infrastructure.Querying;
using LitStar.Infrastructure.UnitOfWork;

namespace LitStar.Repository.NHibernate.Repositories
{
    public class LearningSessionAvailabilityRepository: BaseRepository<LearningSessionAvailability, int>, ILearningSessionAvailabilityRepository
    {
        public LearningSessionAvailabilityRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}