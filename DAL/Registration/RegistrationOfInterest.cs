using DAL.Matching;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Registration
{
    public class RegistrationOfInterest : Entity
    {
        // Teacher info
        [Display(Name = "Förnamn")]
        [RegularExpression("[a-öA-Ö-]*")]
        [MinLength(1)]
        public string FirstName { get; set; }


        [Display(Name = "Efternamn")]
        [RegularExpression("[a-öA-Ö-]*")]
        [MinLength(1)]
        public string LastName { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        [RegularExpression(@"^07\d{8}")]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Skola")]
        public string School { get; set; } // Create tables for School later


        [NotMapped] // prop for select in form
        public int MunicipalityRefId { get; set; }

        [Display(Name = "Kommun")]
        public Municipality Municipality { get; set; }


        [Display(Name = "Adress")]
        public Adress SchoolAdress { get; set; }


        [Display(Name = "Skolform")]
        [Column(TypeName = "nvarchar(24)")]
        public SchoolForm SchoolForm { get; set; }


        [Display(Name = "Ämnen")]
        public ICollection<Subject> Subjects { get; set; }


        // Student group info
        [Display(Name = "Årskurs")]
        public int Grade { get; set; }


        // Only for gymnasie
        [Display(Name = "Program")]
        public string Program { get; set; }


        // Information about meetings
        [Display(Name = "Mötestyp")]
        [Column(TypeName = "nvarchar(24)")]
        public MeetingType MeetingType { get; set; }


        [Display(Name = "Schema")]
        public ICollection<AvailableTimeSpan> ScheduledTimeSpans { get; set; }


        [Display(Name = "Antal Veckor")]
        public int Weeks { get; set; }


        [Display(Name = "Önskat Antal Tillfällen")]
        [Column(TypeName = "nvarchar(24)")]
        public OccassionCount OccassionCount { get; set; }


        [Display(Name = "Tema")]
        public string Theme { get; set; }


        public bool IsInterestedInAnyTheme { get; set; }

        public bool IsInterestedInLongTerm { get; set; }
        // Länk till hemsida för inspiration angående teman

        // If meeting type is physical
        public bool CanVisitMatch { get; set; }

        public bool CanHostMatch { get; set; }


        [InverseProperty("PartyA")]
        public ICollection<MatchCard> MatchCardAsPartyA { get; set; }


        [InverseProperty("PartyB")]
        public ICollection<MatchCard> MatchCardAsPartyB { get; set; }

    }
}
