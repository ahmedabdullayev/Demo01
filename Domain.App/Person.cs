using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class Person
    {
        public Guid id { get; set; }

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