using System;
using System.Collections.Generic;
using SampleCoreWebApi.DataModel.Models;

namespace SampleCoreWebApi.DataModel
{
    public partial class VolunteerVillages
    {
        public int Id { get; set; }
        public int? VolunteerId { get; set; }
        public int? VillageId { get; set; }

        public ConstituencyVillages Village { get; set; }
        public Volunteers Volunteer { get; set; }
    }
}
