using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication1
{
    public class MemberDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sex")]
        public bool isFemale { get; set; }
        [JsonProperty("phone_number")]
        public int PhoneNumber { get; set; }

        [JsonProperty("parents")]
        public List<ParentDto> parents { get; set; }
    }
}
