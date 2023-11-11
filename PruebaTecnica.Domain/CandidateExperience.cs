using System;

namespace PruebaTecnica.Domain
{
    public class CandidateExperience
    {
        public int CandidateExperienceId { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

    }
}
