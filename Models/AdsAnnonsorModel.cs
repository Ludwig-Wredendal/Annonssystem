namespace Annonssystem.Models
{
    public class AdsAnnonsorModel
    {
        public PrenumerantDetalj Prenumerant { get; set; }
        public int pr_prenumerationsnummer { get; set; }
        public int pr_personnummer { get; set; }
        public string? pr_fornamn { get; set; }
        public string? pr_efternamn { get; set; }
        public int pr_telefonnummer { get; set; }
        public string? pr_utdelningsadress { get; set; }
        public int pr_postnummer { get; set; }
        public string? pr_ort { get; set; }

        public AdsDetalj Ad { get; set; }
        public string ad_id { get; set; }
        public int ad_varupris { get; set; }
        public string ad_innehall { get; set; }
        public string ad_rubrik { get; set; }
        public int ad_annonspris { get; set; }
        public AnnonsorerDetalj Annonsorer { get; set;}
        public int an_id { get; set; }
        public bool an_prenumerant { get; set; }
        public int an_ads { get; set; }
        public bool an_foretag { get; set; }
        public string an_namn { get; set; }
        public int an_organisationsnummer { get; set; }
        public int an_telefonnummer { get; set; }
        public string an_utdelningsadress { get; set; }
        public int an_postnummer { get; set; }
        public string an_ort { get; set; }
    }
}
