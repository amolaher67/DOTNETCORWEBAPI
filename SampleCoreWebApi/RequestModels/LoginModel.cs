using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SampleCoreWebApi.BusinessEntities.EntityModels;
using SampleCoreWebApi.Enums;

namespace SampleCoreWebApi.RequestModels
{
    public class LoginModel
    {
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
}
