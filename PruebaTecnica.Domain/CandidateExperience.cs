using PruebaTecnica.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Domain
{
    public class CandidateExperience : BaseDomainModel
    {
        [Key]
        [Column("IdCandidateExperience")]
        public int CandidateExperienceId { get; set; }
        [StringLength(100)]
        public string Company { get; set; }
        [StringLength(100)]
        public string Job { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }

    }
}
