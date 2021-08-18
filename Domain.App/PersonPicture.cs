using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class PersonPicture : DomainEntityId
    {

        [MaxLength(255)]
        public string? PictureUrl { get; set; }
        
        public Person? Person { get; set; }
    }
}