using DAL.Registration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Matching
{
    public class MatchCard : Entity
    {
        [Display(Name = "Grupp A")]
        public RegistrationOfInterest PartyA { get; set; }


        [Display(Name = "Grupp B")]
        public RegistrationOfInterest PartyB { get; set; }


        public ICollection<RegistrationSchedule> TimeSpans { get; set; }


        [Range(1, 52)]
        public int StartWeek { get; set; }
    }
}
