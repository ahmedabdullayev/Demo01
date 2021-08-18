using System;
using Contracts.Domain.Base;

namespace Domain.Base
{
    public class Domain_EntityMeta : IDomainEntityMeta
    {
        public string CreatedBy { get; set; } = "system";
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; } = "system";
        public DateTime UpdatedAt { get; set; }
    }
}