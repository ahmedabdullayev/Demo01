using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PersonPicture
    {
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string PictureUrl { get; set; } = default!;

        public Person? Person { get; set; }
    }
}