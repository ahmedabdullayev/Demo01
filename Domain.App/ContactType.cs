using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class ContactType : DomainEntityId
    {

        [MaxLength(32)] public string ContactTypeValue { get; set; } = default!;

        //[InverseProperty(nameof(Contact.ContactType))]
        public ICollection<Contact>? Contacts { get; set; }
        
       // [InverseProperty(nameof(Contact.SecondaryContactType))]
     //   public ICollection<Contact>? SecondaryContacts { get; set; }
        
    }
}