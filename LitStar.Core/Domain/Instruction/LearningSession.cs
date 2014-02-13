using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;
using System.Runtime.Serialization;
using LitStar.Core.Domain.Account;

namespace LitStar.Core.Domain.Instruction
{
    [Serializable]
    public class LearningSession : EntityBase, ILearningSession, IAggregateRoot
    {
        [DataMember]
        public virtual int TutorID { get; set; }

        [DataMember]
        public virtual int LearnerID { get; set; }

        [DataMember]
        public virtual int LocationID { get; set; }

        [DataMember]
        public virtual DateTime DateOfSession { get; set; }

        [DataMember]
        public virtual DateTime StartTime { get; set; }

        [DataMember]
        public virtual DateTime EndTime { get; set; }

        [DataMember]
        public virtual int PrepHours { get; set; }

        [DataMember]
        public virtual int TravelTimeInMinutes { get; set; }

        [DataMember]
        public virtual string WorkPerformed { get; set; }

        [DataMember]
        public virtual string HomeworkAssigned { get; set; }

        [DataMember]
        public virtual string TutorComments { get; set; }

        [DataMember]
        public virtual string LearnerComments { get; set; }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual Guid SystemID { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        [DataMember]
        public virtual int EnteredBy { get; set; }

        [DataMember]
        public virtual int ChangedBy { get; set; }

        [DataMember]
        public virtual DateTime DateCreated { get; set; }

        [DataMember]
        public virtual DateTime LastUpdated { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
