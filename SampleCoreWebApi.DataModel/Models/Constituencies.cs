using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class Constituencies
    {
        public Constituencies()
        {
            ConstituencyVillages = new HashSet<ConstituencyVillages>();
            PoliticalLeaders = new HashSet<PoliticalLeaders>();
        }

        public int ConstituencyId { get; set; }
        public string ConstituencyName { get; set; }
        public string ConstituencyDistrict { get; set; }
        public string ConstituencyElectionCommition { get; set; }
        public string FutureUse { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<ConstituencyVillages> ConstituencyVillages { get; set; }
        public ICollection<PoliticalLeaders> PoliticalLeaders { get; set; }
    }
}
