using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class ContactType
    {
        public Guid Id { get; set; }

        [MaxLength(32)] public string ContactTypeValue { get; set; } = default!;

        //[InverseProperty(nameof(Contact.ContactType))]
        public ICollection<Contact>? Contacts { get; set; }
        
       // [InverseProperty(nameof(Contact.SecondaryContactType))]
     //   public ICollection<Contact>? SecondaryContacts { get; set; }
        
    }
}