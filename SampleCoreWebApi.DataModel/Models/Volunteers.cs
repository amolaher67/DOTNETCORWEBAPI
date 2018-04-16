using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class Volunteers
    {
        public Volunteers()
        {
            Votings = new HashSet<Votings>();
        }

        public int VolunteerId { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerAddress { get; set; }
        public string VolunteerMobileNumber { get; set; }
        public int? PoliticalLeadersId { get; set; }
        public int? VillageId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDelete { get; set; }

        public PoliticalLeaders PoliticalLeaders { get; set; }
        public ConstituencyVillages Village { get; set; }
        public ICollection<Votings> Votings { get; set; }
    }
}
