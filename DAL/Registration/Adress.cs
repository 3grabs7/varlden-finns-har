using System.ComponentModel.DataAnnotations;

namespace DAL.Registration
{
    public class Adress : Entity
    {
        [Display(Name = "Gatunamn")]
        public string Street { get; set; }


        [Display(Name = "Gatunummer")]
        public string StreetNumber { get; set; }


        [Display(Name = "Postnummer")]
        public string PostalCode { get; set; }


        [Display(Name = "Longitud")]
        public decimal Longitude { get; set; }


        [Display(Name = "Latitud")]
        public decimal Latitude { get; set; }

    }
}
