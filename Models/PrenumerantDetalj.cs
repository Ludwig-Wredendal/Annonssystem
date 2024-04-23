using System.ComponentModel;

namespace Annonssystem.Models
{
    public class PrenumerantDetalj
    {
        // Konstruktor
        public PrenumerantDetalj() { }

        [DisplayName("Prenumerationsnummer")]
        public int pr_prenumerationsnummer {  get; set; }

        [DisplayName("Personnummer")]
        public int pr_personnummer { get; set; }

        [DisplayName("Förnamn")]
        public string? pr_fornamn { get; set; }

        [DisplayName("Efternamn")]
        public string? pr_efternamn { get; set; }

        [DisplayName("Telefon")]
        public int pr_telefonnummer { get; set; }

        [DisplayName("Utdelningsadress")]
        public string? pr_utdelningsadress { get; set; }

        [DisplayName("Postnummer")]
        public int pr_postnummer { get; set; }

        [DisplayName("Ort")]
        public string? pr_ort {  get; set; }

    }
}
