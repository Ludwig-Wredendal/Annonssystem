using System.ComponentModel;

namespace Annonssystem.Models
{
    public class AnnonsorerDetalj
    {
        public AnnonsorerDetalj(){}

        [DisplayName("Annonsör ID")]
        public int an_id { get; set; }

        [DisplayName("Prenumerant")]
        public bool an_prenumerant { get; set; }

        [DisplayName("Annons")]
        public int an_ads { get; set; }

        [DisplayName("Företag")]
        public bool an_foretag { get; set; }

        [DisplayName("Annonsör")]
        public string an_namn { get; set; }

        [DisplayName("Organisationsnummer")]
        public int an_organisationsnummer { get; set; }

        [DisplayName("Telefon")]
        public int an_telefonnummer { get; set; }

        [DisplayName("Utdelningsadress")]
        public string an_utdelningsadress { get; set; }

        [DisplayName("Postnummer")]
        public int an_postnummer { get; set; }

        [DisplayName("Ort")]
        public string an_ort { get; set; }
    }
}
