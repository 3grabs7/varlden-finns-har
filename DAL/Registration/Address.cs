using System.ComponentModel.DataAnnotations;

namespace DAL.Registration
{
    public class Address : Entity
    {
        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Gatuadress")]
        [RegularExpression(@"[a-öA-Ö\d\s]*",
            ErrorMessage = "Gatuaddresser kan endast innehålla bokstäver och siffror.")]
        public string StreetAdress { get; set; }


        [Required(ErrorMessage = "Detta fält måste fyllas i.")]
        [Display(Name = "Postnummer")]
        [RegularExpression(@"\d{5}",
            ErrorMessage = "Postnummer måste bestå utav 5 siffror.")]
        public string PostalCode { get; set; }


        [Display(Name = "Longitud")]
        public decimal Longitude { get; set; }


        [Display(Name = "Latitud")]
        public decimal Latitude { get; set; }

    }
}
