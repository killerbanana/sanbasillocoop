using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace San_Basillo_Credit_Coop_V1.models
{
    

    public partial class Accounts
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("beneficiary")]
        public string[] Beneficiary { get; set; }

        [JsonProperty("personalInfo")]
        public PersonalInfo PersonalInfo { get; set; }
    }

    public partial class PersonalInfo
    {
        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("partner")]
        public string Partner { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("civilStatus")]
        public string CivilStatus { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("contactNumber")]
        public long ContactNumber { get; set; }
    }

    public partial class Accounts
    {
        public static Accounts[] FromJson(string json) => JsonConvert.DeserializeObject<Accounts[]>(json, San_Basillo_Credit_Coop_V1.models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Accounts[] self) => JsonConvert.SerializeObject(self, San_Basillo_Credit_Coop_V1.models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
