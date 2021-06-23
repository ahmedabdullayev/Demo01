using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
{
    public class PersonPicture
    {
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string? PictureUrl { get; set; }
        
        public Person? Person { get; set; }
    }
}