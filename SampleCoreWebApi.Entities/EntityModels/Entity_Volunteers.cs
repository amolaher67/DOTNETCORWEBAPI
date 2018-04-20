using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCoreWebApi.BusinessEntities.EntityModels
{
    public class EntityVolunteers
    {
        public int VolunteerId { get; set; }
        public string VolunteerEmail { get; set; }
        public string VolunteerPassword { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerAddress { get; set; }
        public string VolunteerMobileNumber { get; set; }
        public int? PoliticalLeadersId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDelete { get; set; }
    }
}
