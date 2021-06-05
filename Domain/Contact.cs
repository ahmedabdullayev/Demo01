using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Contact
    {
        /*
         * for mysql/mariadb
         * [MaxLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
         */

        public Guid Id { get; set; }

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