using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CompleteAboutInfoDto
    {
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("found_time")]
        public DateTime FoundDateTime { get; set; }
        [JsonProperty("is_saas_company")]
        public bool ISSAAS { get; set; }
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("members")]
        public List<MemberModel> Members { get; set; }
    }
}