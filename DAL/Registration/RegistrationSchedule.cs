using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Registration
{
    public class RegistrationSchedule : Entity
    {
        [Display(Name = "Veckodag")]
        [Column(TypeName = "nvarchar(24)")]
        public Weekday Weekday { get; set; }


        [Display(Name = "Tid")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Time { get; set; } // Format this to hh:mm (only 30min gaps)


        [Display(Name = "Utanför schema")]
        public bool IsOutsideSchedule { get; set; }

        public RegistrationOfInterest TeacherRegistrationForm { get; set; }

        public bool IsCertain { get; set; }

        public bool IsPossibility { get; set; }


        [NotMapped]
        public bool IsMarked { get; set; }
    }
}
