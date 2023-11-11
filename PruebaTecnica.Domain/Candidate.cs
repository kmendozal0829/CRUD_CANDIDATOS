using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.Domain
{
    public class Candidate
    {
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModidyDate { get; set; }
    }
}
