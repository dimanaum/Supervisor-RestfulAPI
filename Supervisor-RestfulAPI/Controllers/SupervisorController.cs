using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Supervisor_RestfulAPI.Controllers
{
  [ApiController]
  public class SupervisorController : ControllerBase
  {
    private List<Manager> Sort(List<Manager> managers)
    {
      return managers.OrderBy(m => m.Juristiction).ThenBy(m => m.LName).ThenBy(m => m.FName).ToList();
    }

    private void Filter(List<Manager> managers)
    {
      List<Manager> toRemove = new List<Manager>();
      int i;

      foreach(Manager m in managers)
      {
        if(int.TryParse(m.Juristiction, out i))
        {
          toRemove.Add(m);
        }
      }

      managers.RemoveAll(m => toRemove.Contains(m));
    }

    private readonly ILogger<SupervisorController> _logger;

    public SupervisorController(ILogger<SupervisorController> logger)
    {
      _logger = logger;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("api/supervisors")]
    public List<string> Get()
    {
      try
      {
         WebRequest request;
         HttpWebResponse response;

        request = WebRequest.Create("https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/managers");
        request.Method = "GET";
        response = (HttpWebResponse)request.GetResponse();
        if(response.StatusDescription == "OK")
        {
          Stream newStream = response.GetResponseStream();
          StreamReader sr = new StreamReader(newStream);
          var result = sr.ReadToEnd();

          List<Manager> managers = JsonConvert.DeserializeObject<List<Manager>>(result);
          Filter(managers);
          managers = Sort(managers);

          List<string> formattedM = new List<string>();

          foreach(Manager m in managers)
          {
            formattedM.Add(m.Juristiction + " - " + m.LName + ", " + m.FName);
          }

          return formattedM;
        }
        else
        {
          throw (new Exception("Unknown Error"));
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("Exception while processing GET request: " + e.Message);
        return null;
      }
    }
  }
}