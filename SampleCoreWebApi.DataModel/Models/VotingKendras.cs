using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class VotingKendras
    {
        public VotingKendras()
        {
            Votings = new HashSet<Votings>();
        }

        public int VotingKendraId { get; set; }
        public string VotingKendraName { get; set; }
        public int? ConstituencyVillagesId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public ConstituencyVillages ConstituencyVillages { get; set; }
        public ICollection<Votings> Votings { get; set; }
    }
}
