﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Registration
{
    public class Municipality : Entity
    {
        [Display(Name = "Namn")]
        public string Name { get; set; }


        [Display(Name = "Latitud")]
        public double Latitude { get; set; }


        [Display(Name = "Longitud")]
        public double Longitude { get; set; }


        public ICollection<RegistrationOfInterest> RegistrationOfInterests { get; set; }
    }
}
