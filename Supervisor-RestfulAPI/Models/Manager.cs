using Newtonsoft.Json;

namespace Supervisor_RestfulAPI
{
  public class Manager
  {
    [JsonProperty("id")]
    public string ID { get; set; }

    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("jurisdiction")]
    public string Juristiction { get; set; }

    [JsonProperty("identificationNumber")]
    public string IDNum { get; set; }

    [JsonProperty("firstName")]
    public string FName { get; set; }

    [JsonProperty("lastName")]
    public string LName { get; set; }
  }
}
