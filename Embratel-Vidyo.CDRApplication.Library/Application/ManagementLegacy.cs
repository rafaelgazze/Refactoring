using System;
using Embratel_Vidyo.CDRApplication.Library.Http;
using Newtonsoft.Json;

namespace Embratel_Vidyo.CDRApplication.Library.Application
{
    public class ManagementLegacy : IManagement
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int CallId { get; set; }
        public string UserName { get; set; }

        public void Insert()
        {
            if (!ExistsCallId())
                new EmbratelHttpClient().SendPost("api/GenerateDataLegacy/Insert",
                    JsonConvert.SerializeObject(this));
        }

        public  bool ExistsCallId()
        {
            var response = new EmbratelHttpClient().SendPost("api/GenerateDataLegacy/ExistCallId",
                JsonConvert.SerializeObject(new { callId = this.CallId }));

            return JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
