using System.ComponentModel;

namespace Annonssystem.Models
{
    public class AdsDetalj
    {
        public AdsDetalj() { }
        [DisplayName("Annons ID")]
        public int ad_id { get; set; }

        [DisplayName("Varupris")]
        public int ad_varupris {  get; set; }

        [DisplayName("Innehåll")]
        public string ad_innehall { get; set; }

        [DisplayName("Rubrik")]
        public string ad_rubrik { get; set; }

        [DisplayName("Annonspris")]
        public int ad_annonspris { get; set; }

        [DisplayName("Annonsör ID (företag)")]
        public int? ad_annonsor { get; set; }
    }
}
