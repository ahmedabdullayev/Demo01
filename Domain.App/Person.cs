using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class Person : DomainEntityId
    {

        [MaxLength(64)] public string FirstName { get; set; } = default!;
        [MaxLength(64)] public string LastName { get; set; } = default!;

        public ICollection<Contact>? Contacts { get; set; }

        public Guid? PersonPictureId { get; set; }
        public PersonPicture? PersonPicture { get; set; }
        
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}