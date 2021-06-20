using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Registration
{
    public class Municipality : Entity
    {
        [Display(Name = "Namn")]
        public string Name { get; set; }

        public ICollection<RegistrationOfInterest> RegistrationOfInterests { get; set; }
    }
}
