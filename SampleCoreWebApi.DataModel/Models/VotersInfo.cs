using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class VotersInfo
    {
        public int VoterId { get; set; }
        public string IdentityNumber { get; set; }
        public string VoterName { get; set; }
        public string VoterFatherName { get; set; }
        public string HouseNumber { get; set; }
        public int? Ager { get; set; }
        public string Gender { get; set; }
        public bool? IsAlive { get; set; }
        public bool? IsMigrant { get; set; }
        public int VillageId { get; set; }

        public ConstituencyVillages Village { get; set; }
    }
}
