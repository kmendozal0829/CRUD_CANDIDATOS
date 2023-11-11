using System;

namespace PruebaTecnica.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
