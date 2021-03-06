﻿using System;
using System.Collections.Generic;

namespace SampleCoreWebApi.DataModel.Models
{
    public partial class Volunteers
    {
        public Volunteers()
        {
            VolunteerVillages = new HashSet<VolunteerVillages>();
            Votings = new HashSet<Votings>();
        }

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

        public PoliticalLeaders PoliticalLeaders { get; set; }
        public ICollection<VolunteerVillages> VolunteerVillages { get; set; }
        public ICollection<Votings> Votings { get; set; }
    }
}
