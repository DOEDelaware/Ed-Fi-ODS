using System;
using EdFi.Ods.Common.Expando;

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentitySearchRequest : Expando
    {
        public string LastSurname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        //public string GenerationCodeSuffix { get; set; }

        //public string SexType { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? UniqueId { get; set; }

        //public int? BirthOrder { get; set; }  //not used

        //public Location BirthLocation { get; set; }  //not used

        //sk- Added by Delaware to core until extension available

        public Int32 RequestingEducationOrganizationId { get; set; }

        public string SearchIntentType { get; set; }



    }
}