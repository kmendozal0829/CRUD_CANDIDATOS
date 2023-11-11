using PruebaTecnica.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Domain
{
    public class Candidate : BaseDomainModel
    {
        [Key]
        [Column("IdCandidate")]
        public int CandidateId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        [StringLength(250)]
        public string Email { get; set; }


        public ICollection<CandidateExperience> CandidateExperiences { get; set; }
    }
}
