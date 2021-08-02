using DAL.Matching;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Registration
{
    public class RegistrationOfInterest : Entity
    {
        // Teacher info
        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Förnamn")]
        [RegularExpression("[a-öA-Ö-]*", ErrorMessage = "Kan endast innehålla bokstäver.")]
        [MinLength(1, ErrorMessage = "Måste vara minst ett tecken långt.")]
        public string FirstName { get; set; }


        [Display(Name = "Efternamn")]
        [RegularExpression("[a-öA-Ö-]*", ErrorMessage = "Kan endast innehålla bokstäver.")]
        [MinLength(1, ErrorMessage = "Måste vara minst ett tecken långt.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Namn")]
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";


        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [EmailAddress(ErrorMessage = "Ange en giltig email-address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [RegularExpression(@"\d+", ErrorMessage = "Telefonnummer kan endast innehålla siffror")]
        [MinLength(6, ErrorMessage = "Telefonnummret måste vara minst 6 siffror långt.")]
        [MaxLength(12, ErrorMessage = "Telefonnummret får max vara 12 siffror långt.")]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Skola")]
        [RegularExpression("[a-öA-Ö-]*", ErrorMessage = "Kan endast innehålla bokstäver.")]
        public string School { get; set; } // Create tables for School later


        [NotMapped] // prop for select in form
        public int MunicipalityRefId { get; set; }

        //[Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Kommun")]
        public Municipality Municipality { get; set; }


        [Display(Name = "Adress")]
        public Address SchoolAdress { get; set; }


        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Skolform")]
        [Column(TypeName = "nvarchar(24)")]
        public SchoolForm SchoolForm { get; set; }


        [Display(Name = "Ämnen")]
        public ICollection<Subject> Subjects { get; set; }


        // Student group info
        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Årskurs")]
        public int Grade { get; set; }


        // Only for gymnasie
        [Display(Name = "Program")]
        public string Program { get; set; }


        public string OtherSchoolFormTextArea { get; set; }


        // Information about meetings
        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Mötestyp")]
        [Column(TypeName = "nvarchar(24)")]
        public MeetingType MeetingType { get; set; }


        [Display(Name = "Schema")]
        public ICollection<RegistrationSchedule> ScheduledTimeSpans { get; set; }


        [Display(Name = "Antal Veckor")]
        public ICollection<Week> Weeks { get; set; }


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
