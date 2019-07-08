using System.ComponentModel.DataAnnotations.Schema;

namespace lendit.Model
{
    public class Eligibility
    {
        public int EligibilityId { get; set; }

        public string UserHash {get; set;}

        [ForeignKey(nameof(UserHash))]
        public User User { get; set; }
        public int BVN { get; set; }
        public int NIN { get; set; }
        public int VCN {get; set;}
        public string Status {get; set;}
    }
}