namespace Annonssystem.Models
{
    public class AnnonsorerDetalj
    {
        public AnnonsorerDetalj(){}
        public int an_id { get; set; }
        public int an_prenumerant { get; set; }
        public int an_ads { get; set; }
        public int an_foretag { get; set; }
        public string an_namn { get; set; }
        public int an_organisationsnummer { get; set; }
        public int an_telefonnummer { get; set; }
        public string an_utdelningsadress { get; set; }
        public int an_postnummer { get; set; }
        public string an_ort { get; set; }
    }
}
