﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotelSpectral.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String  LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public int  Title { get; set; }
        public String Address { get; set; }
        public String  City { get; set; }
        public String Country { get; set; }
        public int Religion { get; set; }
        public DateTime CreatedDate { get; set; } = new DateTime();

    }
}
