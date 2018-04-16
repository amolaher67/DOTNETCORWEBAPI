using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class PoliticalParty
    {
        public PoliticalParty()
        {
            PoliticalLeaders = new HashSet<PoliticalLeaders>();
            Votings = new HashSet<Votings>();
        }

        public int PoliticalPartyId { get; set; }
        public string PoliticalPartyName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<PoliticalLeaders> PoliticalLeaders { get; set; }
        public ICollection<Votings> Votings { get; set; }
    }
}
