using DAL.Registration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/*
 * TODO
 * - what type of digital tools / expertise
 * - public transport
 * - särskiljda behov, funktionsvariationer
 * 
 * 
 * 
 * 
 */




namespace DAL.Matching
{
    public class MatchCard : Entity
    {
        [Display(Name = "Grupp A")]
        public RegistrationOfInterest PartyA { get; set; }


        [Display(Name = "Grupp B")]
        public RegistrationOfInterest PartyB { get; set; }


        public ICollection<RegistrationSchedule> TimeSpansAvailable { get; set; }

        //public ICollection<RegistrationSchedule> TimeSpansCurrentlyBooked { get; set; }

        // address where meeting will take place
        public Address AddressForMeeting { get; set; }

        [Range(1, 52)]
        public int StartWeek { get; set; }

        public OccassionCount NumberOfMeetings { get; set; }

        //public ICollection<Meeting> Meetings { get; set; }

    }
}
