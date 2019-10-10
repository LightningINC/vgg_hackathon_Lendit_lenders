using System.ComponentModel.DataAnnotations.Schema;

namespace lendit.Model
{
    public class Eligibility
    {
        public int EligibilityId { get; set; }

        public string UserHash {get; set;}

        [ForeignKey(nameof(UserHash))]
        public User User { get; set; }
        public string BVN { get; set; }
        public string NIN { get; set; }
        public string VCN {get; set;}
        public string Status {get; set;}
    }
}