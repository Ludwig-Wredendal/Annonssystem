namespace Annonssystem.Models
{
    public class PrenumerantDetalj
    {
        // Konstruktor
        public PrenumerantDetalj() { }
        public int pr_prenumerationsnummer {  get; set; }
        public int pr_personnummer { get; set; }
        public string? pr_fornamn { get; set; }
        public string? pr_efternamn { get; set; }
        public int pr_telefonnummer { get; set; }
        public string? pr_utdelningsadress { get; set; }
        public int pr_postnummer { get; set; }
        public string? pr_ort {  get; set; }

    }
}
