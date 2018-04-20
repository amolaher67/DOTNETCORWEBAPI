using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class ConstituencyVillages
    {
        public ConstituencyVillages()
        {
            VolunteerVillages = new HashSet<VolunteerVillages>();
            VotersInfo = new HashSet<VotersInfo>();
            VotingKendras = new HashSet<VotingKendras>();
        }

        public int VillageId { get; set; }
        public string VillageName { get; set; }
        public string VillageTaluka { get; set; }
        public string VillageDistrict { get; set; }
        public int? ConstituenciesId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public Constituencies Constituencies { get; set; }
        public ICollection<VolunteerVillages> VolunteerVillages { get; set; }
        public ICollection<VotersInfo> VotersInfo { get; set; }
        public ICollection<VotingKendras> VotingKendras { get; set; }
    }
}
