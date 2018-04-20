using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class PoliticalLeaders
    {
        public PoliticalLeaders()
        {
            Volunteers = new HashSet<Volunteers>();
        }

        public int PoliticalLeaderId { get; set; }
        public string PoliticalLeaderName { get; set; }
        public string PoliticalPartyEmail { get; set; }
        public string PoliticalLeaderAddress { get; set; }
        public string PoliticalLeaderMobileNumber { get; set; }
        public int? ConstituenciesId { get; set; }
        public int? PoliticalPartyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public Constituencies Constituencies { get; set; }
        public PoliticalParty PoliticalParty { get; set; }
        public ICollection<Volunteers> Volunteers { get; set; }
    }
}
