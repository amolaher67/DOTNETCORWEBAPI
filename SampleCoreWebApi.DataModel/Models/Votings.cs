using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class Votings
    {
        public int VotingId { get; set; }
        public int? VolunteersId { get; set; }
        public int? PartyId { get; set; }
        public string ReferenceBy { get; set; }
        public bool? IsActualVoteDone { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int? VotingKendraId { get; set; }

        public PoliticalParty Party { get; set; }
        public Volunteers Volunteers { get; set; }
        public VotingKendras VotingKendra { get; set; }
    }
}
