using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.BusinessEntities.EntityModels
{
    public class EntityPoliticalLeaders
    {
        public int PoliticalLeaderId { get; set; }
        public string PoliticalLeaderName { get; set; }
        public string PoliticalPartyPassword { get; set; }
        public string PoliticalLeaderAddress { get; set; }
        public string PoliticalLeaderMobileNumber { get; set; }
        public int? ConstituenciesId { get; set; }
        public int? PoliticalPartyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
