using Newtonsoft.Json;

namespace Supervisor_RestfulAPI
{
  public class Employee
  {
    [JsonProperty("firstName")]
    public string FName { get; set; }

    [JsonProperty("lastName")]
    public string LName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("phoneNumber")]
    public string Phone { get; set; }

    [JsonProperty("supervisor")]
    public string Supervisor { get; set; }
  }
}
