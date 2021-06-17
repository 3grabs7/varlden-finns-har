using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Registration
{
    public class MatchCard : Entity
    {
        [Display(Name = "Grupp A")]
        public RegistrationOfInterest PartyA { get; set; }


        [Display(Name = "Grupp B")]
        public RegistrationOfInterest PartyB { get; set; }


        public ICollection<AvailableTimeSpan> TimeSpans { get; set; }


        [Range(1, 52)]
        public int StartWeek { get; set; }
    }
}
