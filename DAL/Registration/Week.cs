using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Registration
{
    public class Week : Entity
    {
        [Display(Name = "Veckonummer")]
        public int WeekNumber { get; set; }


        [Display(Name = "År")]
        public int Year { get; set; }

        public ICollection<RegistrationOfInterest> RegistrationOfInterests { get; set; } 


        [NotMapped]
        public bool IsMarked { get; set; }
    }
}
