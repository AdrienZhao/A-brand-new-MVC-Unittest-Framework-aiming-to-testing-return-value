using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ShortFormatAboutInfoDto
    {
        [JsonProperty("about_us")]
        public string AboutUS { get; set; }
    }
}