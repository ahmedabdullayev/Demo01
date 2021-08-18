using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Contact : DomainEntityId
    {
        /*
         * for mysql/mariadb
         * [MaxLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
         */


        [MaxLength(36)] public string ContactValue { get; set; } = null!;
        //[MaxLength(36)] public string SecondaryContactValue { get; set; } = null!;
        
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public Guid ContactTypeId { get; set; }
        public ContactType? ContactType { get; set; }
        
        // public Guid SecondaryContactTypeId { get; set; }
        // public ContactType? SecondaryContactType { get; set; }
    }
}