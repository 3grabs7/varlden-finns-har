using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Registration
{
    public class Week : Entity
    {
        [Display(Name = "Veckonummer")]
        public int WeekNumber { get; set; }


        [Display(Name = "År")]
        public int Year { get; set; }


        public ICollection<RegistrationOfInterest> Weeks { get; set; }
    }
}
